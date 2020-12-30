using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//简单工厂角色
///<summary>
///坦克工厂类
///</summary>
public class GhostFactory : MonoBehaviour
{
    private GameObject prefab_GhostA;
    private GameObject prefab_GhostB;

    void Awake()
    {
        prefab_GhostA = Resources.Load<GameObject>("Blinky");
        prefab_GhostB = Resources.Load<GameObject>("Inky");
    }
    ///<summary>
    ///创建坦克
    ///</summary>
    public EnemyBase CreateGhost(string ghostName)
    {
        EnemyBase EnemyBase = null;
        switch (ghostName)
        {
            case "GhostA":
                EnemyBase = GameObject.Instantiate<GameObject>(prefab_GhostA).GetComponent<EnemyBase>();
                EnemyBase.InitGhost(2, 100);
                break;
            case "GhostB":
                EnemyBase = GameObject.Instantiate<GameObject>(prefab_GhostB).GetComponent<EnemyBase>();
                EnemyBase.InitGhost(4, 200);
                break;
        }
        return EnemyBase;
    }
}