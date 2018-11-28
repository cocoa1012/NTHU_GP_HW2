using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

	// Use this for initialization

	public ballGenerater bG;
	public int ballRemain;
	public int score;
	public Canvas status;
	public Text Score;
	public Text Remain;
	public Text endingScore;
	public Canvas gameOver;
	public Canvas setting;
	public Canvas choose;
	public int diffculty;

	public static titleControler tC;
	void Start () {
		bG.enabled = false;
		Time.timeScale = 0;
		gameOver.enabled = false;
		setting.enabled = false;
		score = 0;
		ballRemain = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (ballRemain <1){
			showEnding();
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			showSetting();
		}
	}
	
	public void addScore(){
		score += 1;
		Score.text = "Score: "+score;
		Remain.text = "Remain: "+ballRemain;
	}
	public void addGolden(){
		score += 2;
		Score.text = "Score: "+score;
		Remain.text = "Remain: "+ballRemain;
	}

	public void addBall(){
		ballRemain +=1;
		Remain.text = "Remain: "+ballRemain;
	}

	public void subBall(){
		ballRemain -=1;
		Remain.text = "Remain: "+ballRemain;
	}

	public void showEnding(){
		endingScore.text = "Score: "+score;
		gameOver.enabled = true;
		Time.timeScale = 0;
	}

	public void showSetting(){
		setting.enabled = true;
		Time.timeScale = 0;
	}

	public void retry(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void backToGame(){
		setting.enabled = false;
		Time.timeScale = 1;
	}


	public void exit(){
		Application.Quit();
	}
	
	public void setDiffculty(int d){
		// print (d);
		if (d>0){
			diffculty = d;
			choose.enabled = false;
			choose.GetComponentInChildren<Dropdown>().interactable = false;
			Destroy(choose);
			bG.startGenBall(3.5f - d);
			Time.timeScale = 1;
		}
		
	}

	public void setVolume(float v){
		titleControler.tC.GetComponent<AudioSource>().volume = v;
	}

}