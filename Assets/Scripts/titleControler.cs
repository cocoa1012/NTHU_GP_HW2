using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleControler : MonoBehaviour {

	// Use this for initialization

	public Canvas info;
	AudioSource aud;

	public static titleControler tC;

	void Awake()
	{
		tC = this;
		DontDestroyOnLoad(this.gameObject);		
	}
	void Start () {
		aud = gameObject.GetComponent<AudioSource>();
		info.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enterGame(){
		SceneManager.LoadScene("main");
	}

	public void exit(){
		Application.Quit();
	}

	public void showInfo(){
		info.enabled = true;
	}

	public void hideInfo(){
		info.enabled = false;
	}
}
