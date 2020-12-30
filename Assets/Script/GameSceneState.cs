using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏界面场景
/// </summary>
public class GameSceneState : ISceneState
{
    public GameSceneState(SceneStateController controller)
        : base("03GameScene", controller)
    {
    }
}
