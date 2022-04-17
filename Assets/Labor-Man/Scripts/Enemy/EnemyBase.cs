using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
public class EnemyBase : MonoBehaviour
{
    public float Speed => _enemySpeed;

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
    private void Update()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        _enemySpeed = transform.position.x;
        Transform myTransform = this.transform;
        Vector2 pos = myTransform.localPosition;
        while (_move == Move.Right)
        {
            pos.x -= _enemySpeed;
        }
        while (_move == Move.Left)
        {
            pos.x += _enemySpeed;
        }
        myTransform.position = pos;
        void OnTriggerEnter2D(Collider2D collision)
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
    }
    enum Move
    {
        Idle,
        Right,
        Left
    }

}
