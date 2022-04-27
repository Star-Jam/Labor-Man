using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour,IDamageble

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


    void IDamageble.AddDamage(int damage)
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
