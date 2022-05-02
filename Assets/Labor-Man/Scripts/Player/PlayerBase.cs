using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public abstract class PlayerBase : MonoBehaviour, IDamageble
{
    public bool IsGodMode => _isGodMode;
    public int HP => _hp;
    public int Power => _power;
    public bool Direction => _direction;

    [SerializeField]
    [Header("無敵モード")]
    bool _isGodMode = false;

    [SerializeField]
    [Header("右のMuzzleのポジション")]
    protected Transform _rigthMuzzle;

    [SerializeField]
    [Header("左のMuzzleのポジション")]
    protected Transform _leftMuzzle;

    [SerializeField]
    [Header("Playerのスピード")]
    protected float _speed = 10f;

    [SerializeField]
    [Header("攻撃力")]
    int _power;

    [SerializeField]
    [Header("PlayerのHP")]
    int _hp = 100;

    [SerializeField]
    [Header("ジャンプ力")]
    float _jumpPower = 10f;

    [SerializeField]
    [Header("攻撃のインターバル")]
    int _interval = 2;

    [SerializeField]
    [Header("敵のタグ")]
    string _enemyTag = "Enemy";

    [SerializeField]
    [Header("Itemのタグ")]
    string _itemTag = "Item";

    [SerializeField]
    [Header("地面のタグ")]
    string _groundTag = "Ground";

    [SerializeField]
    [Header("壁のタグ")]
    string _wallTag = "Wall";

    [SerializeField]
    [Header("敵の攻撃のタグ")]
    string _enemyBulletTag = "EnemyBullet";

    [SerializeField]
    [Header("ゲームゾーンのタグ")]
    string _gameZoneTag = "GameZone";

    [SerializeField]
    [Header("遠距離攻撃時に生成したいオブジェクト")]
    protected GameObject _attackGameObject;


    protected Rigidbody2D _rb;
    protected Vector2 _dir;
    SpriteRenderer _sp;
    protected Transform _muzzle;

    bool _canAttack = true;
    bool _isGrounded = false;
    bool _direction;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _muzzle = _rigthMuzzle;
        _direction = true;
    }

    protected void OnDisable()
    {
        GameManager.Instance.GameOver();
    }

    protected abstract void Attack();

    protected abstract void SpecialAttack();

    protected virtual void Heal(int recoveryAmount)
    {
        _hp += recoveryAmount;
    }

    public void AddDamage(int damage)
    {
        _hp -= damage;
        PlayerDeath();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputMoveMent = context.ReadValue<Vector2>();
        _dir.x = inputMoveMent.x;
        _rb.velocity = _dir.normalized * _speed;
        Inversion();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;
        if (context.started)
        {
            _rb.velocity = Vector2.up * _jumpPower;
        }
    }

    public async void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _canAttack = false;
            Attack();
            await Task.Delay(_interval);
            _canAttack = true;
        }
    }

    public async void OnSpecialAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _canAttack = false;
            SpecialAttack();
            await Task.Delay(_interval);
            _canAttack = true;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _groundTag || collision.gameObject.tag == _wallTag)
        {
            _isGrounded = true;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _groundTag || collision.gameObject.tag == _wallTag)
        {
            _isGrounded = false;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _gameZoneTag)
        {
            Destroy(this.gameObject);
        }
    }

    void PlayerDeath()
    {
        if(_hp < 1)
        {
            Destroy(gameObject);
        }
    }

    void Inversion()
    {
        if (_dir.x > 0)
        {
            _sp.flipX = false;
            _muzzle = _rigthMuzzle;
            _direction = false;
        }
        else if (_dir.x < 0)
        {
            _sp.flipX = true;
            _muzzle = _leftMuzzle;
            _direction = true;
        }
    }
}
