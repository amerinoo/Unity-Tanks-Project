﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementScript : MonoBehaviour
{
	public float speedLinear = 15.0f;
	public float speedRotate = 1.0f;
	private Rigidbody rb;
	private List<Transform> continuousTracks;
	private float forward, left;
	private Transform turret;
	private Transform canon;
	private float minAngleTurret = 0.0f;
	private float maxAngleTurret = 355.0f;

	void Start ()
	{		
		rb = GetComponent<Rigidbody> () as Rigidbody;
		turret = transform.Find ("Turret");
		canon = transform.Find ("Turret/CanonParent/Canon");
		continuousTracks = new List<Transform> ();
		foreach (Transform child in transform) {
			if (child.CompareTag ("ContinuousTrack"))
				continuousTracks.Add (child);
		}
	}

	void Update ()
	{
		float axisH = Input.GetAxis ("Horizontal");
		float factor = 0.5f + axisH / -2.0f * 0.5f;
		if (rb.velocity.magnitude < 0.1f && Mathf.Abs (axisH) > 0.1f) {
			continuousTracks [0].GetComponent<ContinousTrackScript> ().linearSpeed = speedLinear * -left * 0.5f;
			continuousTracks [1].GetComponent<ContinousTrackScript> ().linearSpeed = speedLinear * left * 0.5f;
		} else {
			continuousTracks [0].GetComponent<ContinousTrackScript> ().linearSpeed = rb.velocity.magnitude * forward * factor;
			continuousTracks [1].GetComponent<ContinousTrackScript> ().linearSpeed = rb.velocity.magnitude * forward * (1 - factor);
		}

	}

	public void MoveForward (float v = 1.0f)
	{
		forward = 1.0f;
		Vector3 tmp = transform.forward * speedLinear * v;
		rb.velocity = new Vector3 (tmp.x, rb.velocity.y, tmp.z);
	}

	public void MoveBackward (float v = -1.0f)
	{
		forward = -1.0f;
		Vector3 tmp = transform.forward * speedLinear * v;
		rb.velocity = new Vector3 (tmp.x, rb.velocity.y, tmp.z);
	}

	public void TurnLeft (float h = -1.0f)
	{
		left = -1.0f;
		rb.MoveRotation (Quaternion.Euler (0.0f, speedRotate * h, 0.0f) * rb.rotation);
	}

	public void TurnRight (float h = 1.0f)
	{
		left = 1.0f;
		rb.MoveRotation (Quaternion.Euler (0.0f, speedRotate * h, 0.0f) * rb.rotation);
	}

	public void TurnTurretLeft (float ht = -1.0f)
	{
		turret.Rotate (turret.up, speedRotate * ht);
	}

	public void TurnTurretRight (float ht = 1.0f)
	{
		turret.Rotate (turret.up, speedRotate * ht);
	}

	public void TurnTurretUp (float vt = 1.0f)
	{
		if (canon.eulerAngles.x < minAngleTurret + 1.0f)
			canon.Rotate (speedRotate * vt, 0.0f, 0.0f);
		else if (canon.eulerAngles.x > maxAngleTurret)
			canon.Rotate (speedRotate * vt, 0.0f, 0.0f);
	}

	public void TurnTurretDown (float vt = -1.0f)
	{
		if (canon.eulerAngles.x < minAngleTurret)
			canon.Rotate (speedRotate * vt, 0.0f, 0.0f);
		else if (canon.eulerAngles.x > maxAngleTurret - 1.0f)
			canon.Rotate (speedRotate * vt, 0.0f, 0.0f);
	}

	public void HideBody ()
	{
		GameObject go = transform.Find ("Turret/ManWithButton").gameObject;
		go.SetActive (!go.activeSelf);
	}
}
