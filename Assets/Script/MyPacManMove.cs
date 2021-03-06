﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPacManMove : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式


    public float speed = 1;//位移速度
    Vector3 diff;//位移偏差值

    public int i = 0;//相机编号

    private void Start()
    {
        gameMode = GameObject.Find("Camera");//共有4个相机
    }

    private void FixedUpdate()
    {
        GetDiff();
        Move();
    }

    /// <summary>
    /// 根据偏差方向实现位移
    /// </summary>
    void Move()
    {
        //游戏进行中时玩家可以移动
        if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Playing)
        {
            transform.LookAt(this.transform.position + diff);
            this.transform.position += diff * speed;
        }
    }

    /// <summary>
    /// 根据按钮获取偏差方向，并改变相应相机参数
    /// </summary>
    void GetDiff()
    {
        if (Input.GetKey(KeyCode.A))
        {
            diff = new Vector3(-1, 0, 0);
            //i = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            diff = new Vector3(0, 0, -1);
            //i = 3;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            diff = new Vector3(1, 0, 0);
            //i = 2;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            diff = new Vector3(0, 0, 1);
            //i = 1;
        }
        else
            diff = Vector3.zero;
    }

    /// <summary>
    /// 检测豆子的碰撞，销毁豆子，播放特效和声音
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        GameObject[] collections = GameObject.FindGameObjectsWithTag("Collections");
        if (other.tag == "Collections")
        {
            if (collections.Length == 1)//胜利条件:最后一个
            {
                //设置游戏状态为胜利
                gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Win;
                //播放声音
                //gameMode.GetComponent<MyAudioManager>().PlayAudio(3);
                gameMode.GetComponent<MyAudioManager>().PlayLongAudio(5);
                Destroy(other.gameObject);
            }
            else//还未胜利
            {
                gameMode.GetComponent<MyAudioManager>().PlayAudio(0);
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "Enemy")
            {
                gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.GameOver;
                gameMode.GetComponent<MyAudioManager>().PlayAudio(2);
                gameMode.GetComponent<MyAudioManager>().PlayLongAudio(4);
            }
        
    }
}
