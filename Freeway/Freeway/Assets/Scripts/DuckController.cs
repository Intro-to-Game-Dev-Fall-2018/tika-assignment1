using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuckController : MonoBehaviour
{
	public int moveSpeed = 5;
	Rigidbody2D myRigidBody;
    Animator myAnimator;

	private int score;
	private float seconds;
	public float delay;

	private bool isMovable;

	public Text scoreText;
	public Text timeText;

	public GameObject OtherPlayer;
	public GameObject DuckWall;
	
	// Use this for initialization
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		
		score = 0;
		seconds = 120f;
		isMovable = true;
		delay = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{
		seconds -= Time.deltaTime;
		timeText.text = "" + (int) seconds;
		
		myRigidBody.velocity = new Vector2(0, 0);

		if (isMovable == true)
		{
			if (Input.GetKey(KeyCode.W))
			{
				myAnimator.Play("Dude-Back");
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed);
			}

			if (Input.GetKey(KeyCode.S))
			{
				myAnimator.Play("Duck-Front");
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -moveSpeed);
			}
		}

		else
		{
			ExecuteDelay();
		}	

		if (seconds <= 0)
		{
			if (score > OtherPlayer.gameObject.GetComponent<Duck2Controller>().getScore())
			{
				SceneManager.LoadScene("Duck1Victory");
			}
			
			else if (score < OtherPlayer.gameObject.GetComponent<Duck2Controller>().getScore())
			{
				SceneManager.LoadScene("Duck2Victory");
			}

			else
			{
				SceneManager.LoadScene("TieScene");
			}
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("upper"))
		{
			transform.position = new Vector2(DuckWall.gameObject.transform.position.x, DuckWall.gameObject.transform.position.y);
			isMovable = false;
			score++;
			scoreText.text = score.ToString();
		}

		if (collisionInfo.gameObject.CompareTag("leftcar"))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f * collisionInfo.gameObject.GetComponent<LeftDirection>().moveSpeed);
			isMovable = false;
		}
		
		if (collisionInfo.gameObject.CompareTag("rightcar"))
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f * collisionInfo.gameObject.GetComponent<RightDirection>().moveSpeed);
			isMovable = false;
		}
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

	
}
	
	
