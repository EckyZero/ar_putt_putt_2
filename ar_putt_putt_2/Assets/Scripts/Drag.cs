using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Ball))]
public class Drag : MonoBehaviour {

	Vector3 _initialPosition;
	float _initialTime;
	float _dampener = 0.05f;
	Ball _ball;

	#region Lifecycle

	void Start () 
	{
		_ball = gameObject.GetComponent<Ball>();
	}

	void Update () 
	{
		var currentVerticalPosition = _ball.RigidBody.position.y;

		Debug.Log("VERTICAL POSITION: " + currentVerticalPosition);

		if (currentVerticalPosition < 0.1f) 
		{
			_ball.RigidBody.position = new Vector3(x: _ball.RigidBody.position.x,
												   y: 0.1f,
												   z: _ball.RigidBody.position.z);
		}
	}

	#endregion

	#region Public Methods

	public void DragStart () 
	{
		_initialPosition = Input.mousePosition;
		_initialTime = Time.time;
	}

	public void DragEnd () 
	{
		Debug.Log("DRAG END CALLED");

		var currentPosition = Input.mousePosition;
		var currentTime = Time.time;
		var duration = currentTime - _initialTime;

		var speedX = _dampener * (currentPosition.x - _initialPosition.x)/duration;
		var speedZ = _dampener * (currentPosition.y - _initialPosition.y)/duration;

		var velocity = new Vector3(speedX, 0, speedZ);

		_ball.Launch(velocity);
	}

	#endregion
}