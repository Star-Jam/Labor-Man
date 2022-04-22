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

    public float EnemyHp => _enemyHp; 
    [SerializeField]
    [Header("EnemyのHP")]
    float _enemyHp = 1f;

    [SerializeField]
    [Header("壁のtag")]
    string _wallTag;

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
        //Vector2 pos = _myTransform.localPosition;
        if (_move == Move.Right)
        {
            _myTransform.Translate(_enemySpeed, 0, 0);
        }
        if (_move == Move.Left)
        {
            _myTransform.Translate(-_enemySpeed, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _wallTag)
        {
            if (_move == Move.Left)
            {
                _move = Move.Right;
            }
            if (_move == Move.Right)
            {
                _move = Move.Right;
            }
        }
     }
    enum Move
    {
        Idle,
        Right,
        Left
    }

}
