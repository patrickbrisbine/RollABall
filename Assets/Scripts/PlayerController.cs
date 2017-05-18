using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed = 1;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Called before every frame is rendered
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Called before performing physics calculations
    /// </summary>
    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }
}
