using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyBase : MonoBehaviour, IDamageble
{
    public float Speed => _enemySpeed;
    Transform _myTransform = default;
    public int EnemyHp => _enemyHp; 
    SpriteRenderer _sp;

    [SerializeField]
    [Header("Enemyのスピード")]
    float _enemySpeed = 0f;

    [SerializeField]
    [Header("Speedを抑制する値")]
    float _enemySpeedControl = 100;

    [SerializeField]
    [Header("EnemyのHP")]
    int _enemyHp = 1;

    [SerializeField]
    [Header("壁のtag")]
    string _wallTag = "Wall";

    [SerializeField]
    [Header("プレイヤーのtag")]
    string _playerTag = "Player";

    [SerializeField]
    [Header("エネミーのtag")]
    string _enemyTag = "Enemy";

    [SerializeField]
    [Header("プレイヤーと接触時に与えるダメージ")]
    int _onEnemyDamage = default;

    [SerializeField]
    Move _move = Move.Idle;

    public int OnEnemyDamage => _onEnemyDamage;

    private void OnEnable()
    {
        _sp = GetComponent<SpriteRenderer>();
        _myTransform = this.transform;
        if (_move == Move.Left)
        {
            _sp.flipX = false;
        }
        else if (_move == Move.Right)
        {
            _sp.flipX = true;
        }
    }

    private void Update()
    {
        EnemyMove();
    }
    void OnBecameVisible()
    {
        this.gameObject.SetActive(true);
    }
    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
    void EnemyMove()
    {
        if (_move == Move.Left)
        {
            _myTransform.Translate(-_enemySpeed / _enemySpeedControl, 0, 0);
        }
        if (_move == Move.Right)
        {
            _myTransform.Translate(_enemySpeed / _enemySpeedControl, 0, 0);
        }
    }
    void EnemyDeath()
    {
        if(_enemyHp < 1)
        {
            Destroy(this. gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag || collision.gameObject.tag == _enemyTag)
        {
            if (_move == Move.Right)
            {
                _move = Move.Left;
                _sp.flipX = false;
            }
            else if (_move == Move.Left)
            {
                _move = Move.Right;
                _sp.flipX = true;
            }
        }
        if (collision.gameObject.tag == _playerTag)
        {
            collision.gameObject.GetComponent<IDamageble>().AddDamage(_onEnemyDamage);

        }
     }

    public void AddDamage(int damage)
    {
        _enemyHp -= damage;
        EnemyDeath();
    }

    enum Move
    {
        Idle,
        Left,
        Right
    }

}
