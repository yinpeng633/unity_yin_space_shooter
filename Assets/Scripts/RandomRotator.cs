﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization
	private Rigidbody rb; //陨石对象

	public float tumble;
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;  //设置角速度，这个可是三维角速度
	}
	
	
}
