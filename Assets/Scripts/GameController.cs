using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Game控制器，控制游戏的整体逻辑，随机刷敌机，判断玩家game end ,和得分。

    //第一步完成 随机刷敌机任务。
    public GameObject hazard;  //这里是 随机刷的陨石块。

    public Vector3 spawnValues;

    public int spawnCount;  //每波生产几个
    public float spawnWait; //生产间隔

    public float startWait; //启动生产间隔
    public float waveWait; //生产波间隔


    //生产随机位置的陨石方法
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Quaternion quaternion = Quaternion.identity;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, quaternion);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
       StartCoroutine(SpawnWaves());
    }



}
