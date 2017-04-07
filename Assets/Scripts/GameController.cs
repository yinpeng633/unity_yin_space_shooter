using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Game控制器，控制游戏的整体逻辑，随机刷敌机，判断玩家game end ,和得分。

    //第一步完成 随机刷敌机任务。
    public GameObject[] hazards;  //这里是 随机刷的陨石块。
    public GUIText scoreText;

    private int score;

    public Vector3 spawnValues;

    public int spawnCount;  //每波生产几个
    public float spawnWait; //生产间隔

    public float startWait; //启动生产间隔
    public float waveWait; //生产波间隔

    //游戏重启和结束
    private bool gameOver;
    private bool gameRestart;
    public GUIText gameOverText;
    public GUIText restartText;


    


    //生产随机位置的陨石方法
    IEnumerator SpawnWaves()
    {
        //这里屌炸天啊 感觉，yield c#的语法糖
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Quaternion quaternion = Quaternion.identity;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, quaternion);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "按R键重新开始游戏";
                gameRestart = true;
                break; //跳出循环
            }
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameOver = false;
        gameRestart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves()); //这个方法估计就是把一个可枚举的事件序列,在游戏线程上，一个个遍历执行。
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "得分：" + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "游戏结束";
    }



}
