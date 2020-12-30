using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController mSceneStateController;
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        mSceneStateController = new SceneStateController();
        //设置默认状态
        mSceneStateController.ChangeState(new StartSceneState(mSceneStateController), false);
    }

    private void Update()
    {
        if (mSceneStateController != null)
        {
            mSceneStateController.UpdateState();
        }
    }
}
