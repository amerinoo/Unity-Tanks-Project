﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Magazine
{
	public Bullet bullet;
	public int maxBullets;
	[HideInInspector]
	public int remainingBullets;

	public void setDefaults ()
	{
		remainingBullets = maxBullets;
	}
}
