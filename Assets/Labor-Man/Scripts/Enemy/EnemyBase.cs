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
    Move _move = Move.Idle;
    void EnemyMove()
    {
        _enemySpeed = transform.position.x;
        if (_move == Move.Right)
        {
            _enemySpeed++;
        }
    }
    enum Move
    {
        Idle,
        Right,
        Left
    }

}
