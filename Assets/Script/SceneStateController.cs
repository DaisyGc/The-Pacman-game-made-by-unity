using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景状态控制类
/// </summary>
public class SceneStateController
{
    private ISceneState mNowSceneState;
    public ISceneState NowSceneState { get; set; }

    /// <summary>
    /// 用于判断场景是否加载完成
    /// </summary>
    private AsyncOperation mAsyncOperation;

    /// <summary>
    /// 当进入场景时执行EnterScene，且只执行一次
    /// </summary>
    private bool mDoOnceEnterScene = false;


    /// <summary>
    /// 每帧更新场景
    /// </summary>
    public void UpdateState()
    {
        //正在加载场景过程中时不更新
        if (mAsyncOperation != null && mAsyncOperation.isDone == false) return;

        //刚进入游戏场景时更新一次
        //if (mAsyncOperation.isDone==true && mDoOnceEnterScene == false)
        {
            mNowSceneState.EnterScene();
            mDoOnceEnterScene = true;
        }

        //Update一直更新
        if (mNowSceneState != null)
        {
            mNowSceneState.UpdateScene();
        }
    }

    internal void SetState(GameSceneState gameSceneState)
    {
        throw new NotImplementedException();
    }

    public void SetState(MainMenuSceneState mainMenuSceneState)
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// 改变场景
    /// </summary>
    public void ChangeState(ISceneState state, bool isLoadScene = true)
    {
        if (mNowSceneState != null)
        {
            mNowSceneState.LeaveScene();
        }
        mNowSceneState = state;

        //是否需要加载场景，第一个不需要加载
        if (isLoadScene)
        {
            mAsyncOperation = SceneManager.LoadSceneAsync(state.SceneName);
            mDoOnceEnterScene = false;
        }
        else
        {
            mNowSceneState.EnterScene();
            mDoOnceEnterScene = true;
        }
    }
}
