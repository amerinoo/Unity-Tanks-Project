﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRandomCubesScript : MonoBehaviour
{
	public Collider r;
	public GameObject prefab;
	public string objectName;
	public int max;
	public float y = 0;
	// Use this for initialization
	void Start ()
	{
		
		float lx = r.bounds.size.x;
		float lz = r.bounds.size.z;
		float factor = 0.1f;
		for (int i = 0; i < max; i++) {
			GameObject go = Instantiate (prefab, new Vector3 (
				                Random.Range (lx * factor, lx - lx * factor) + r.transform.position.x / 1.5f, y,
				                Random.Range (lz * factor, lz - lz * factor) + r.transform.position.z / 1.5f), 
				                Quaternion.Euler (0.0f, Random.Range (0.0f, 90.0f), 0.0f));
			go.name = objectName + " " + i;
			go.transform.parent = transform.Find (objectName);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
