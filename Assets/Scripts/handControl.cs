using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handControl : MonoBehaviour {

	// Use this for initialization
	public float mX;
	public float mY;
	public float speed;
	public bool isJump;
	public gameController gc;
	public ParticleSystem ball;
	public ParticleSystem golden;

	public ParticleSystem bonus;

	public static titleControler tC;

	public AudioClip catchBall;
	public AudioClip catchBonus;

	int score;
	Rigidbody m_rigid;
	void Start () {
		ball.Stop();
		golden.Stop();
		bonus.Stop();
		score = 0;
		speed = 15.0f;
		m_rigid = gameObject.GetComponent<Rigidbody>();
		isJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		mX = Input.GetAxis("Horizontal");
		mY = Input.GetAxis("Vertical");
		if (Input.GetButtonDown("Jump")){
			if (isJump == false){
				m_rigid.AddForce(0, 300, 0);
				isJump = true;
			}
		}
		gameObject.transform.Translate(speed * mX * Time.deltaTime, 0.5f * speed * -mY * Time.deltaTime, 0);
	}
	private void FixedUpdate()
	{

	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ball"){
			gc.addScore();
			ball.Play();
			Destroy(other.gameObject);
			titleControler.tC.GetComponent<AudioSource>().PlayOneShot(catchBall);
			// ball.enableEmission = false;
		}
		if (other.gameObject.tag == "gloden"){
			gc.addGolden();
			golden.Play();
			Destroy(other.gameObject);
			titleControler.tC.GetComponent<AudioSource>().PlayOneShot(catchBall);
			// golden.enableEmission = false;
		}
		if (other.gameObject.tag == "bonus"){
			gc.addBall();
			bonus.Play();
			Destroy(other.gameObject);
			titleControler.tC.GetComponent<AudioSource>().PlayOneShot(catchBonus);
			// bonus.enableEmission = false;
		}
		if (other.gameObject.tag == "ground"){
			isJump = false;
		}
	}
}
