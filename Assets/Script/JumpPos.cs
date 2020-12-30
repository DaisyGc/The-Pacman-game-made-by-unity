using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpPos : MonoBehaviour
{
   public void JumpScene()
   {
        AsyncOperation ass = SceneManager.LoadSceneAsync("03GameScene", LoadSceneMode.Additive);
    }
    public void JumpSetting()
    {
        SceneManager.LoadScene("cdrl1");
    }
}
