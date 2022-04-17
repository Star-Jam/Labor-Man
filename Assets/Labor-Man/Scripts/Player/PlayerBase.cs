using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageble
{
    Rigidbody2D _rb;

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
    [Header("攻撃のインターバル")]
    float _interval;

    [SerializeField]
    [Header("Itemのタグ")]
    string _itemTag;

    public bool IsGodMode => _isGodMode;

    public float Speed => _speed;

    public int HP => _hp;

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
}
