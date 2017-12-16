using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour {

	Vector3 _initialPosition;
	float _initialTime;

	private Renderer Renderer;
	public Rigidbody RigidBody;

	#region Lifecycle

	void Start () 
	{
		RigidBody = GetComponent<Rigidbody>();
		Renderer = gameObject.GetComponentInChildren<MeshRenderer>();

		gameObject.SetActive(false);
	}

	#endregion


	#region Public Methods

	public void Launch (Vector3 velocity)
	{
		gameObject.SetActive(true);

		RigidBody.velocity = velocity;
	}

	public void Reset ()
	{
		RigidBody.position = new Vector3(x:0f, y:0.2f, z:0f);
		RigidBody.velocity = new Vector3(x:0f, y:0.0f, z:0f);

		gameObject.SetActive(true);
	}

	#endregion
}