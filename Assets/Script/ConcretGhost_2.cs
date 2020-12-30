using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//具体产品2
public class ConcretGhost_2: EnemyBase
{
    public override void GhostShoot()
    {
        base.GhostShoot();
        Debug.Log("我是幽灵B，攻击两次角色死亡");
    }
}