using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有坦克管理器--->直接访问工厂类，对抽象产品进行实例化
/// </summary>
public class GhostManager : MonoBehaviour
{

    private List<string> ghostList;//创建一个列表

    private GhostFactory _GhostFactory;//实例化工厂类
    void Start()
    {
        _GhostFactory = gameObject.GetComponent<GhostFactory>();
        ghostList = new List<string>();//初始化列表
        ghostList.Add("GhostA");//A类
        ghostList.Add("GhostB");//B类
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int index = Random.Range(0, ghostList.Count);//[0,3)
            EnemyBase enemyBase = _GhostFactory.CreateGhost(ghostList[index]);//随机创建
            enemyBase.GhostMove();
            enemyBase.GhostShoot();
            Debug.Log(enemyBase.ToString());
        }
    }
}