using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹超出这个边界就会销毁临时产生的子弹对象。
public class BoundaryDestroyer : MonoBehaviour {

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);  //子弹碰到即刻销毁。
	}
	
}
