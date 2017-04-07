using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSize;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(scrollSpeed * Time.time, tileSize);
		transform.position = startPosition + Vector3.forward * newPosition;
		// Debug.Log("newPosition=" + newPosition);
		// Debug.Log("Time.time=" + Time.time);
	}
}
