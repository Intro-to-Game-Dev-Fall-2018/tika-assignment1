using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDirection : MonoBehaviour
{

	public float moveSpeed;
	public GameObject wall;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("rightwall"))
		{
			gameObject.transform.position = new Vector2(wall.gameObject.GetComponent<Transform>().position.x, wall.gameObject.GetComponent<Transform>().position.y);
		}
	}
}
