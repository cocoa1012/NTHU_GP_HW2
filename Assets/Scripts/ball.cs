using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	public gameController gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.Find("gameController").GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 0){
			Destroy(this.gameObject);
			gc.subBall();
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ground"){
			Destroy(this.gameObject);
			gc.subBall();
		}
	}

}
