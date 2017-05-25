using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject ZigZagPanel;
	public GameObject GameOverPanel;
	public GameObject TapText;
	public Text Score;
	public Text HighScore1;
	public Text HighScore2;

	void Awake(){
		if( instance == null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		HighScore1.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		
		TapText.SetActive (false);
		ZigZagPanel.GetComponent<Animator> ().Play ("PanelUp");
	}

	public void GameOver(){
		Score.text = PlayerPrefs.GetInt ("Score").ToString();
		HighScore2.text = PlayerPrefs.GetInt ("HighScore").ToString();
		GameOverPanel.SetActive (true);
	}

	public void Reset(){
		SceneManager.LoadScene (0);
	}
}
