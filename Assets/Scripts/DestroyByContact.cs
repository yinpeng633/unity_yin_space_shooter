﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject arstroidExplosion; //陨石爆炸效果

    public GameObject PlayerExplosion; //玩家飞机爆炸效果
    public int itemScore;

    private GameController gameController;

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

        gameController.AddScore(itemScore);
        Destroy(other.gameObject);  //销毁撞击体
        Destroy(gameObject);  //销毁被撞击体，即改脚本绑定的gameObject
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("找不到GameController脚本");
        }
    }

}
