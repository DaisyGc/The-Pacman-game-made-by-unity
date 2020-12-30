using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject pacman;
	public GameObject blinky;
	public GameObject clyde;
	public GameObject inky;
	public GameObject pinky;
	public GameObject startPanel;
	public GameObject gamePanel;
	public GameObject startCountDownPrefab;
	public GameObject gameoverPrefab;
	public GameObject winPrefab;
	public AudioClip startClip;
    public GameObject DotNum;
    public Text eatnum;
    public Text RemainNum;
	private void Start()
	{
		SetGameState(false);
        DotNum = GameObject.FindGameObjectWithTag("Maze");
	} 
	public void OnStartButton()
	{
		StartCoroutine(PlayStartCountDown());
		AudioSource.PlayClipAtPoint(startClip, new Vector3(0, 0, -5));
		startPanel.SetActive(false);
	}

    private void Update()
    {
        CheckDotsNum();
    }

    public void OnExitButton()
	{
		Application.Quit();
	} 
	IEnumerator PlayStartCountDown()
	{
		GameObject go = Instantiate(startCountDownPrefab);
		yield return new WaitForSeconds(4f);
		Destroy(go);
		SetGameState(true);
		gamePanel.SetActive(true);
		GetComponent<AudioSource>().Play();
	} 
	private void SetGameState(bool state)
	{
		pacman.GetComponent<PacmanMove>().enabled = state;
		blinky.GetComponent<GhostMove>().enabled = state;
	    clyde.GetComponent<GhostMove>().enabled = state;
		inky.GetComponent<GhostMove>().enabled = state;
		pinky.GetComponent<GhostMove>().enabled = state;
	}
    public void CheckDotsNum()
    {
        eatnum.text=Pacdot.Eatnum.ToString();
        int i = DotNum.GetComponent<Transform>().childCount;
        RemainNum.text = (i).ToString();
        if (Pacdot.Eatnum==214)
        {
            SceneManager.LoadScene("Trick");
        }
        //if(Pacdot.Eatnum==544)
        //{
        //    SceneManager.LoadScene("Trick");
        //}
    }
}