using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 开始界面场景
/// </summary>
public class StartSceneState : ISceneState
{
    public StartSceneState(SceneStateController controller)
        : base("01StartScene", controller)
    {
    }
    //Logo图片
    private Image mLogo;

    public override void EnterScene()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
    }
    public override void UpdateScene()
    {
        //设置logo渐渐显示
        mLogo.DOColor(Color.white, 5).OnComplete(() =>
        {
            mSceneStateController.SetState(new MainMenuSceneState(mSceneStateController));
            SceneManager.LoadScene("02MainMenuScene");
            //GameObject.Find("Main Camera").GetComponent<GameLoop>().enabled = false;
            
        });
    }
}
