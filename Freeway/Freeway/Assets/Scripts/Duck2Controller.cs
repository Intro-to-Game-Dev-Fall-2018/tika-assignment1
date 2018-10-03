using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Duck2Controller : MonoBehaviour
{
	public int moveSpeed = 5;
	Rigidbody2D myRigidBody;
	Animator myAnimator;

	private int score;
	public Text scoreText;
	
	public float delay;

	private bool isMovable;

	public GameObject DuckWall;
	
	private AudioSource audioSource;
	public AudioClip[] list;

	// Use this for initialization
	void Start()
	{
		list =  new AudioClip[]{(AudioClip)Resources.Load("Sounds/cash"),
			(AudioClip)Resources.Load("Sounds/scream1"),
			(AudioClip)Resources.Load("Sounds/scream2"), 
			(AudioClip)Resources.Load("Sounds/scream3"),
			(AudioClip)Resources.Load("Sounds/scream4"), 
			(AudioClip)Resources.Load("Sounds/scream5")};
		
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		
		score = 0;
		isMovable = true;
		delay = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{
		myRigidBody.velocity = new Vector2(0, 0);

		if (isMovable == true)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				myAnimator.Play("Girl-Back");
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed);
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				myAnimator.Play("Girl-Front");
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -moveSpeed);
			}
		}

		else
		{
			ExecuteDelay();
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("upper"))
		{
			audioSource.clip = list[0];
			audioSource.Play();
			transform.position = new Vector2(DuckWall.gameObject.transform.position.x, DuckWall.gameObject.transform.position.y);
			isMovable = false;
			score++;
			scoreText.text = score.ToString();
		}
		
		if (collisionInfo.gameObject.CompareTag("leftcar"))
		{
			setAudio();
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f * collisionInfo.gameObject.GetComponent<LeftDirection>().moveSpeed);
			isMovable = false;
		}
		
		if (collisionInfo.gameObject.CompareTag("rightcar"))
		{
			setAudio();
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f * collisionInfo.gameObject.GetComponent<RightDirection>().moveSpeed);
			isMovable = false;
		}
	}

	public int getScore()
	{
		return score;
	}
	
	private void ExecuteDelay()
	{
		delay -= Time.deltaTime;

		if (delay <= 0)
		{
			isMovable = true;
			delay = 0.5f;
		}
	}
	
	private void setAudio()
	{
		int randomInt = Random.Range(1, 6);
		audioSource.clip = list[randomInt];
		audioSource.Play();
	}
	
}