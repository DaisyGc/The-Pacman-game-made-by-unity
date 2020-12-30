using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景状态基类
/// </summary>
public class ISceneState
{
    //根据场景名字加载场景
    public string mSceneName;
    public string SceneName { get { return mSceneName; } }

    public SceneStateController mSceneStateController;

    public ISceneState(string sceneName, SceneStateController sceneStateController)
    {
        mSceneName = sceneName;
        mSceneStateController = sceneStateController;
    }

    //场景的进入、更新、离开
    public virtual void EnterScene() { }
    public virtual void UpdateScene() { }
    public virtual void LeaveScene() { }
}
