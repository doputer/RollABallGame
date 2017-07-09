using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// 물리 관련 변수 선언
	public float speed;
	public Rigidbody rb;

	// 움직임 관련 변수 선언
	private bool isJumping;
	private float posY;
	private float gravity;
	private float jumpPower;
	private float jumpTime;

	// 점수 관련 변수 선언
	private int count;

	public Text countText;
	public Text winText;

	void Start()
	{
		speed = 10.0f;

		count = 0;
		SetCountText ();
		winText.text = "";

		// gravity와 jumpPower을 조작하여 점프력 조작
		isJumping = false;
		posY = transform.position.y;
		gravity = 9.8f;
		jumpPower = 5.0f;
		jumpTime = 0.0f;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (Input.GetKeyDown (KeyCode.Space) && !isJumping) {
			isJumping = true;
			posY = transform.position.y;
		}
		if (isJumping) {
			Jump ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}

	void Jump()
	{
		float height = jumpTime * jumpTime * (-gravity / 2) + (jumpTime * jumpPower);
		transform.position = new Vector3 (transform.position.x, posY + height, transform.position.z);
		jumpTime += Time.deltaTime;

		if (height < 0.0f) {
			isJumping = false;
			jumpTime = 0.0f;
			transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
		}
	}
}