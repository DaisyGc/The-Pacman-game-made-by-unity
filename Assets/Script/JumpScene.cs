﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour
{
    public void JumpVoid()
    {
        SceneManager.LoadScene("Exit");
    }
    public void ExitTheGame()
    {
        SceneManager.LoadScene("_ChompMan-PM/Scenes/Level_01");
    }
}
