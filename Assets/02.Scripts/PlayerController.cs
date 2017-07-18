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
	private float moveHorizontal;
	private float moveVertical;
	private bool isJumping;
	private float jumpPower;
	private int jumpCount;

	// 점수 관련 변수 선언
	private int count;
	public int pickupCount;
	private GameObject[] pickupArray;

	public Text countText;
	public Text winText;

	// 스테이지 클리어 관련 변수 선언
	public GameObject clearStage;

	void Start()
	{
		speed = 13.0f;

		// 오브젝트 관련
		count = 0;
		winText.text = "";

		pickupArray = GameObject.FindGameObjectsWithTag ("PickUp");
		pickupCount = pickupArray.Length;

		SetCountText ();

		// gravity와 jumpPower을 조작하여 점프력 조작
		isJumping = false;
		jumpPower = 5.5f;

		jumpCount = 0;

		// 게임 시작 시 마우스 설정
		Cursor.lockState = CursorLockMode.Locked;
 	}

	void Update()
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		if (Input.GetKeyDown (KeyCode.Space) && jumpCount == 0) {
			isJumping = true;
		}

		if (rb.position.y < -10) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	void FixedUpdate()
	{
		Run ();
		Jump ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Flag")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Terrain")) {
			jumpCount = 0;
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString () + " / " + pickupCount;
		if (count >= pickupCount) {
			winText.text = "You Win!";
			clearStage.SetActive (true);
		}
	}

	void Run()
	{
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed, ForceMode.Force);
	}

	void Jump()
	{
		if(!isJumping)
			return;
		rb.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
		isJumping = false;
		jumpCount = 1;
	}
}