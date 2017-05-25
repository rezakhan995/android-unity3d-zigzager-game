using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {


	public static ScoreManager instance;
	public int Score;
	public int HighScore;

	void Awake(){
		if( instance == null ){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		Score = 0;
		PlayerPrefs.SetInt ("Score", Score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementScore(){
		Score += 1;
	}

	public void StartScore(){
		InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}

	public void StopScore(){
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt ("Score", Score);

		if (PlayerPrefs.HasKey ("HighScore")) {
			if (Score > PlayerPrefs.GetInt ("HighScore")) {
				PlayerPrefs.SetInt ("HighScore", Score);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", Score);
		}
	}
}
