﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	public float time;
	public bool pause;
	public GameObject player;
	public bool playerDead;

	private UIControllerScript uics;

	// Use this for initialization
	void Start ()
	{
		player = Instantiate (Resources.Load ("Tanks/" + StaticData.tank))as GameObject;
		GameObject go = Instantiate (Resources.Load ("Levels/" + StaticData.level))as GameObject;
		GameObject.FindGameObjectWithTag ("Player").transform.position = go.transform.Find ("Skeleton/InitialPoint").transform.position;
		uics = GetComponent<UIControllerScript> ();
		uics.Setup ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1))
			player.SendMessage ("DamagePlayer", 1);
		
		if (Input.GetKeyDown (KeyCode.Alpha2))
			player.SendMessage ("GivePoints", 10);
		
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			GiveTime (50);
			player.SendMessage ("DamagePlayer", -3);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}

		if (pause) {
			
		} else {
			time -= Time.deltaTime;
			if (time <= 0.0f || PlayerDead ())
				EndGame ();
			
		}
	}

	bool PlayerDead ()
	{
		return playerDead;
	}

	public void PlayerDead (int playerNum)
	{
		playerDead = true;
	}

	public void Pause ()
	{
		pause = true;
		uics.Pause ();
		Time.timeScale = 0.0f;
	}

	public void Resume ()
	{
		pause = false;
		uics.Resume ();
		Time.timeScale = 1.0f;
	}

	public void EndGame ()
	{
		Pause ();
	}

	void GiveTime (int i)
	{
		this.time += i;
	}


	public void GoMenu ()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("main");
	}


	void OnApplicationPause (bool pauseStatus)
	{
		
		if (pauseStatus)
			Pause ();
	}
}
