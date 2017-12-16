using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {

	Vector3 _initialPosition;
	float _initialTime;
	Rigidbody _rigidBody;

	#region Lifecycle

	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		
	}

	#endregion

	#region Public Methods

	public void DragStart () 
	{
		Debug.Log("DRAG START CALLED");

		_initialPosition = Input.mousePosition;
		_initialTime = Time.time;

		Debug.Log("DRAG START POSITION: " + _initialPosition);
	}

	public void DragEnd () 
	{
		Debug.Log("DRAG END CALLED");

		var currentPosition = Input.mousePosition;
		var currentTime = Time.time;
		var duration = currentTime - _initialTime;

		var speedX = (currentPosition.x - _initialPosition.x)/duration;
		var speedZ = (currentPosition.y - _initialPosition.y)/duration;

		var velocity = new Vector3(speedX, 0, speedZ);

		Debug.Log("DRAG END POSITION: " + currentPosition);
		Debug.Log("DRAG END VELOCITY: " + velocity);

		Launch(velocity);
	}

	#endregion

	#region Private Methods

	private void Launch (Vector3 velocity)
	{
		_rigidBody.useGravity = true;

		_rigidBody.velocity = velocity;
//		_audioSource.Play ();
//		_isLaunched = true;
	}

	#endregion
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//
//[RequireComponent(typeof(BowlingBall))]
//public class DragLaunch : MonoBehaviour {
//
//	// Variables
//	BowlingBall _ball;
//	Vector3 _initialPosition;
//	float _initialTime;
//
//
//	// Use this for initialization
//	void Start () {
//		_ball = gameObject.GetComponent<BowlingBall>();
//	}
//
//	public void DragStart() {
//		_initialPosition = Input.mousePosition;
//		_initialTime = Time.time;
//	}
//
//	public void DragEnd() {
//		var currentPosition = Input.mousePosition;
//		var currentTime = Time.time;
//		var duration = currentTime - _initialTime;
//
//		var speedX = (currentPosition.x - _initialPosition.x)/duration;
//		var speedZ = (currentPosition.y - _initialPosition.y)/duration;
//
//		var velocity = new Vector3(speedX, 0, speedZ);
//
//		_ball.Launch(velocity);
//	}
//}
