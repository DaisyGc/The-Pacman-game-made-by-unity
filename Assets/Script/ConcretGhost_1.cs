using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//具体产品1
public class ConcretGhost_1: EnemyBase
{
    public override void GhostShoot()
    {
        base.GhostShoot();
        Debug.Log("我是幽灵A，攻击三次角色死亡");
    }
}