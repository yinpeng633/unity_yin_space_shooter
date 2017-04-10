using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{

    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public float dodge;
	public float smoothing;
    private float startZv;
    private float targetManeuver;
    // Use this for initialization
    private Rigidbody rb;
    public Boundary boundary;
	public float tilt;
    void Start()
    {
        StartCoroutine(Evade());
        rb = GetComponent<Rigidbody>();
        startZv = rb.velocity.z;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        // 上面这个方法的源码
        // public static float MoveTowards(float current, float target, float maxDelta)
        // {
        //     if (Mathf.Abs(target - current) <= maxDelta)
        //     {
        //         return target;
        //     }
        //     return current + Mathf.Sign(target - current) * maxDelta;
        // }
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, smoothing * Time.deltaTime);

        rb.velocity = new Vector3(newManeuver, 0.0f, startZv);

		//不让敌机漂移出边界被销毁。
        rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

		rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }


    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);  //始终往x的反方向运动
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;  //怎么知道敌机这时已经漂移到上一个目标位置了？
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
}
