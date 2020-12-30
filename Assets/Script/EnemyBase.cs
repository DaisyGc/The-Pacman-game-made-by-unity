using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///所有坦克类的父类
///</summary>

public class EnemyBase : MonoBehaviour
{
    private int moveSpeed;
    ///<summary>
    ///移动速度
    ///</summary>
    public int MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    private int lifeValue;
    ///<summary>
    ///生命值
    ///</summary>
    public int LifeValue
    {
        get { return lifeValue; }
        set { lifeValue = value; }
    }
    ///<summary>
    ///初始化坦克属性
    ///</summary>
    public void InitGhost(int moveSpeed, int lifeValue)
    {
        this.moveSpeed = moveSpeed;
        this.LifeValue = lifeValue;
    }
    ///<summary>
    ///坦克移动的虚方法
    ///</summary>
    public virtual void GhostMove()
    {
        Debug.Log("幽灵移动");
    }
    ///<summary>
    ///坦克射击
    ///</summary>
    public virtual void GhostShoot()
    {
        Debug.Log("开始攻击");
    }
    public override string ToString()
    {
        return string.Format("移动速度:{0},生命值:{1}", this.moveSpeed, this.lifeValue);
    }
}