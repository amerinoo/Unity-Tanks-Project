﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerScript : MonoBehaviour
{
	public GameObject pauseUI;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Pause ()
	{
		pauseUI.SetActive (true);
	}

	public void Resume ()
	{
		pauseUI.SetActive (false);
	}
}
