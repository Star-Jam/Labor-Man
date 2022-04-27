using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyBase : MonoBehaviour
{
    public float Speed => _enemySpeed;
    Transform _myTransform = default;

    [SerializeField]
    [Header("Enemyのスピード")]
    float _enemySpeed = 0f;

    [SerializeField]
    [Header("Speedを抑制する値")]
    float _enemySpeedControl = 100;


    public float EnemyHp => _enemyHp; 
    [SerializeField]
    [Header("EnemyのHP")]
    float _enemyHp = 1f;

    [SerializeField]
    [Header("壁のtag")]
    string _wallTag = "Wall";

    [SerializeField]
    Move _move = Move.Idle;


    private void Start()
    {
        _myTransform = this.transform;
    }

    private void Update()
    {
        EnemyMove();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            Vector3 _scale = transform.localScale;
            if (_move == Move.Right)
            {
                _move = Move.Left;
                _scale.x = 1;
            }
            else if (_move == Move.Left)
            {
                _move = Move.Right;
                _scale.x = -1;
            }
            transform.localScale = _scale;
        }
     }
    enum Move
    {
        Idle,
        Left,
        Right
    }

}
