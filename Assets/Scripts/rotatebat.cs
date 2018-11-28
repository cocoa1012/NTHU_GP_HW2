using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebat : MonoBehaviour {

	// Use this for initialization
	public GameObject pivot;
	public Vector3 pivotPos;
	void Start () {
		pivotPos = pivot.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.RotateAround(pivotPos,Vector3.up, -720 * Time.deltaTime);
	}
}
