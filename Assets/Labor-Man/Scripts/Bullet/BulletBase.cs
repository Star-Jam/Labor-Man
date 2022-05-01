using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class BulletBase : MonoBehaviour
{
    [SerializeField]
    [Header("弾のSpeed")]
    protected float _bulletSpeed;

    [SerializeField]
    [Header("ダメージ量")]
    protected int _damage;

    [SerializeField]
    [Header("動かすタイミング")]
    MoveMode _moveMode;

    [SerializeField]
    [Header("動かす方向を決めるかどうか")]
    bool _isDecisionDirection = false;

    [SerializeField]
    [Header("動かす方向")]
    Direction _direction;

    protected Vector2 _dir = Vector2.one;
    Rigidbody2D _rb;
    SpriteRenderer _sp;

    enum MoveMode
    {
        Strat,
        Update
    }

    enum Direction
    {
        Left,
        Right
    }

    protected virtual void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        if (!_isDecisionDirection) FiringFoeFront();
        DecisionDirection();
        if (_moveMode == MoveMode.Strat)
        {
            BulletMove();
        }
    }

    protected virtual void Update()
    {
        if(_moveMode == MoveMode.Update)
        {
            BulletMove();
        }
    }

    protected virtual void BulletMove()
    {
        _rb.velocity = _dir * _bulletSpeed;
    }

    protected void DecisionDirection()
    {
        if(_direction == Direction.Left)
        {
            _dir = Vector2.left;
        }
        else if(_direction == Direction.Right)
        {
            _dir = Vector2.right;
        }
    }

    void FiringFoeFront()
    {
        if(GameManager.Instance.Player.Direction)
        {
            _direction = Direction.Left;
            _sp.flipX = true;
        }
        else
        {
            _direction = Direction.Right;
        }
    }
}
