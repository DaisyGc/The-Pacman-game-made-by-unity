using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDot : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject=(PacDot.Instance().GenerateObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isSuperPacdot = false;//判断是否为超级豆子，默认为false

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Pacman")//判断碰撞的物体的“名字”==“Pacman”
    //    {
    //        if (isSuperPacdot)//超级豆子
    //        {

    //            GameManager.Instance.OnEatSuperPacdot();//调用GameManager脚本中的OnEatSuperPacdot方法
    //            Destroy(gameObject);//销毁此物体
    //        }
    //        else
    //        {
    //            GameManager.Instance.OnEatPacdot(gameObject);//调用GameManager脚本中的OnEatPacdot（gameobject）方法
    //            Destroy(gameObject);//销毁此物体
    //        }

    //    }
    //}
}
