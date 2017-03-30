using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject arstroidExplosion; //陨石爆炸效果

    public GameObject PlayerExplosion; //玩家飞机爆炸效果

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }

		Instantiate(arstroidExplosion, other.transform.position, other.transform.rotation);

        if (other.tag == "Player")
        {
			Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
