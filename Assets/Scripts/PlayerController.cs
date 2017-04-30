using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed = 10.0f;
	public Text countText;

	private Rigidbody2D rb2d;
	private int count;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		SetStringText ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed, ForceMode2D.Force);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetStringText ();
		}
	}

	void SetStringText()
	{
		countText.text = "Count: " + count;
	}
}
