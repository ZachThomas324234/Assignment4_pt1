using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : SphereCollision
{
    public override void OnCollisionEnter(Collision collision)
    {
        EnemyDamage = 15;
        base.OnCollisionEnter(collision);
    }

}
