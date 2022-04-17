using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour, IDamageble
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
    [Header("敵のタグ")]
    string _enemyTag;

    [SerializeField]
    [Header("PlayerのHP")]
    int _hp;

    [SerializeField]
    [Header("ジャンプ力")]
    float _jumpPower;

    [SerializeField]
    [Header("攻撃のインターバル")]
    float _interval;

    [SerializeField]
    [Header("Itemのタグ")]
    string _itemTag;

    [SerializeField]
    [Header("地面のタグ")]
    string _groundTag;

    public bool IsGodMode => _isGodMode;

    public int HP => _hp;

    bool _isGrounded = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Attack()
    {
        Debug.Log("Attack!");
    }

    protected void Heel(int recoveryAmount)
    {
        _hp += recoveryAmount;
    }

    public void AddDamage(int damage)
    {
        _hp -= damage;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputMoveMent = context.ReadValue<Vector2>();
        _dir = new Vector2(inputMoveMent.x, inputMoveMent.y);
        Debug.Log(_dir);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _groundTag)
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _groundTag)
        {
            _isGrounded = false;
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
