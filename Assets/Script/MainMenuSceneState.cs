using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主菜单界面场景
/// </summary>
public class MainMenuSceneState : ISceneState
{
    public MainMenuSceneState(SceneStateController controller) : base("02MainMenuScene", controller)
    {
    }
    //当用户点击按钮时，进入游戏场景
    private Button mGameStartBtn;

    public override void EnterScene()
    {
        mGameStartBtn = GameObject.Find("GameStartButton").GetComponent<Button>();
        mGameStartBtn.onClick.AddListener(OnGameStartBtnClick);
    }

    private void OnGameStartBtnClick()
    {
        mSceneStateController.SetState(new GameSceneState(mSceneStateController));
    }
}
