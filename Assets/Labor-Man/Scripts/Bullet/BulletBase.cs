using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class BulletBase : MonoBehaviour

{
    [SerializeField]
    [Header("Muzzleのポジション")]
    Transform _muzzle;

    [SerializeField]
    [Header("弾のSpeed")]
    float _bulletSpeed;

    [SerializeField]
    [Header("ダメージ量")]
    int _damage;

    [SerializeField]
    [Header("動かすタイミング")]
    MoveMode _moveMode;

    Vector2 _dir;
    Rigidbody2D _rb;

    enum MoveMode
    {
        Strat,
        Update
    }

    protected virtual void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_moveMode == MoveMode.Strat)
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
}
