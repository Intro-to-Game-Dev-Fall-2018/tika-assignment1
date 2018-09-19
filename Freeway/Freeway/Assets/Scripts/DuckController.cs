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

	private int score;
	private float seconds;

	public Text scoreText;
	public Text timeText;

	public GameObject OtherPlayer;
	
	// Use this for initialization
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		score = 0;
		seconds = 120f;
	}

	// Update is called once per frame
	void Update()
	{
		myRigidBody.velocity = new Vector2(0, 0);

		if (Input.GetKey(KeyCode.W))
		{
			myRigidBody.velocity += new Vector2(0, moveSpeed);
		}

		if (Input.GetKey(KeyCode.S))
		{
			myRigidBody.velocity -= new Vector2(0, moveSpeed);
		}

		seconds -= Time.deltaTime;
		timeText.text = "" + (int) seconds;

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
			transform.position = new Vector2(-6.17f, -4.274f);
			score++;
			scoreText.text = score.ToString();

		}
	}
	
}
	
	
