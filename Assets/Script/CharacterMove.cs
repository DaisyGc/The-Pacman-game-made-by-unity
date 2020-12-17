using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    //public float speed = 1;//位移速度
    Vector3 diff;//位移偏差值

    private float speed = 5;
    private Transform m_Transform;

    public int i = 0;//相机编号

    public Text ShowRemain;
    public Text ShowScore;
    public Text ShowTime;

    public static int dotNum = 0;
    public Transform Dots;

    private float intervelTime=1;
    public static float totalTime = 100;

    void Start()
    {
        gameMode = GameObject.Find("Camera");//共有4个相机
        m_Transform = this.transform;
        ShowTime.text = totalTime.ToString();

        StartCoroutine(CountDown());
    }

    void FixedUpdate()
    {
        Move();
        CalculateDotsNum();
    }

    private void Update()
    {
        if (totalTime > 0)
        {
            intervelTime -= Time.deltaTime;
            if (intervelTime <= 0)
            {
                intervelTime += 1;
                totalTime--;
                ShowTime.text = totalTime.ToString();
            }
        }
    }

    private IEnumerator CountDown()
    {
        while (totalTime > 0)
        {
            yield return new WaitForSeconds(1);
            totalTime--;
        }
    }

    public void CalculateDotsNum()
    {
        int dotorigin = 150;
        ShowRemain.text = (dotorigin-dotNum).ToString();
    }

    void Move()
    {
        //游戏进行中时玩家可以移动
        if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Playing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                m_Transform.localRotation = Quaternion.Euler(0, 0, 0);
                m_Transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_Transform.localRotation = Quaternion.Euler(0, 180, 0);
                m_Transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_Transform.localRotation = Quaternion.Euler(0, -90, 0);
                m_Transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_Transform.localRotation = Quaternion.Euler(0, 90, 0);
                m_Transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
        }
    }

    /// <summary>
    /// 根据按钮获取偏差方向，并改变相应相机参数
    /// </summary>
    

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
                dotNum++;
                ShowScore.text = dotNum.ToString();
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
