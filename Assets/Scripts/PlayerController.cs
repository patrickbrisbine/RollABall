/* 
 * RollABall Copyright (C) Patrick Brisbine - All Rights Reserved
 *
 * RollABall is licensed under a Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License.
 *
 * You should have received a copy of the license along with this
 * work.  If not, see <http://creativecommons.org/licenses/by-nc-nd/3.0/>.
 *  
 * Written by Patrick Brisbine December 2017
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed = 1;
	public Text scoreText;
	public Text winText;

	public string time;

	private int score;

	void Start() {
		rb = GetComponent<Rigidbody>();
		score = 0;
		setScoreText ();
		winText.text = "";
	}

    /// <summary>
    /// Called before every frame is rendered
    /// </summary>
    void Update() {
		if (score < 13) {
			time = Time.realtimeSinceStartup.ToString ();
		}
		setScoreText ();
    }

    /// <summary>
    /// Called before performing physics calculations
    /// </summary>
    void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }

	void setScoreText() {
		scoreText.text = "Score: " + score + "\r\nDuration: " + time;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			score = score + 1;
			if (score == 13) {
				time = Time.realtimeSinceStartup.ToString ();
				winText.text = "You Win!";
			}

			setScoreText ();
		}
	}
}