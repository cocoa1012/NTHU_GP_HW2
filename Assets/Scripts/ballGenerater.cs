using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballGenerater : MonoBehaviour {

	public GameObject ballGen;
	public Object[] ball;

	private int ballType;

	public gameController gc;
	public static titleControler tC;
	public AudioClip hitBall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGenBall(float delayTime){
		InvokeRepeating("shootBall", 0.0f, delayTime);
	}

	void shootBall(){
		ballType = Random.Range(0,10);
		GameObject Ball = GameObject.Instantiate(ball[ballType], Vector3.zero, Quaternion.identity) as GameObject;
		Ball.transform.position = gameObject.transform.position;
		Ball.GetComponent<Rigidbody>().AddForce((gameObject.transform.forward+ Random.Range(0.7f,1.0f) * gameObject.transform.up + Random.Range(-0.1f,0.1f) * gameObject.transform.right) * 3.50f);
		titleControler.tC.GetComponent<AudioSource>().PlayOneShot(hitBall);
	}
}
