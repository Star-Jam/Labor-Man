using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{
    protected override void Attack()
    {
        Instantiate(_attackGameObject, _muzzle);
        Debug.Log("a");
    }
    protected override void SpecialAttack()
    {
        Debug.Log("s");
    }
}
