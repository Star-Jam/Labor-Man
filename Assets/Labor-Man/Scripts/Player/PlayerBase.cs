using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public abstract class PlayerBase : MonoBehaviour, IDamageble
{
    Rigidbody2D _rb;
    Vector2 _dir;
    SpriteRenderer _sp;

    [SerializeField]
    [Header("無敵モード")]
    bool _isGodMode = false;

    [SerializeField]
    [Header("Playerのスピード")]
    float _speed;

    [SerializeField]
    [Header("攻撃力")]
    int _power;

    [SerializeField]
    [Header("敵のタグ")]
    string _enemyTag;

    [SerializeField]
    [Header("Itemのタグ")]
    string _itemTag;

    [SerializeField]
    [Header("地面のタグ")]
    string _groundTag;

    [SerializeField]
    [Header("壁のタグ")]
    string _wallTag;

    [SerializeField]
    [Header("PlayerのHP")]
    int _hp;

    [SerializeField]
    [Header("ジャンプ力")]
    float _jumpPower;

    [SerializeField]
    [Header("攻撃のインターバル")]
    int _interval;

    [SerializeField]
    [Header("敵の攻撃のタグ")]
    string _enemyBulletTag;


    public bool IsGodMode => _isGodMode;
    public int HP => _hp;

    bool _canAttack = true;
    bool _isGrounded = false;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    protected abstract void Attack();

    protected abstract void SpecialAttack();

    protected virtual void Heal(int recoveryAmount)
    {
        _hp += recoveryAmount;
    }

    void IDamageble.AddDamage(int damage)
    {
        _hp -= damage;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputMoveMent = context.ReadValue<Vector2>();
        _dir.x = inputMoveMent.x;
        _rb.velocity = _dir * _speed;
        Inversion();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;
        if(context.started)
        {
            _rb.velocity = Vector2.up * _jumpPower;
        }
    }

    public async void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _canAttack = false;
            Attack();
            await Task.Delay(_interval);
            _canAttack = true;
        }
    }

    public async void OnSpecialAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _canAttack = false;
            SpecialAttack();
            await Task.Delay(_interval);
            _canAttack = true;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _groundTag)
        {
            _isGrounded = true;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _groundTag)
        {
            _isGrounded = false;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _enemyTag)
        {
            //IDamageble.AddDamage(collision.gameObject.GetComponent<EnemyBase>().Power);
        }

        if(collision.tag == _enemyBulletTag)
        {
            //IDamageble.AddDamage(collision.GetComponent<BulletBase>().Power);
        }
    }

    void Inversion()
    {
        if (_dir.x > 0)
        {
            _sp.flipX = false;
        }
        else if (_dir.x < 0)
        {
            _sp.flipX = true;
        }
    }
}
