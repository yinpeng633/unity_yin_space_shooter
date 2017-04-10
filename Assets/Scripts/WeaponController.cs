using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpan;
	private AudioSource audiosource;

	public float fireRate;
	public float fireDalay;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource>();
		InvokeRepeating("Fire", fireDalay, fireRate); //内置的定时调用方法
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Fire()
	{
		Instantiate(shot, shotSpan.position, shotSpan.rotation);
		audiosource.Play();
	}
}
