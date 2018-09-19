using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Duck2Controller : MonoBehaviour
{
	public int moveSpeed = 5;
	Rigidbody2D myRigidBody;

	private int score;
	public Text scoreText;

	// Use this for initialization
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		myRigidBody.velocity = new Vector2(0, 0);

		if (Input.GetKey(KeyCode.UpArrow))
		{
			myRigidBody.velocity += new Vector2(0, moveSpeed);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			myRigidBody.velocity -= new Vector2(0, moveSpeed);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("upper"))
		{
			transform.position = new Vector2(7.624f, -4.274f);
			score++;
			scoreText.text = score.ToString();
		}
	}

	public int getScore()
	{
		return score;
	}
	
}