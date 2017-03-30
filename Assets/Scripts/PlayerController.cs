using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody rb;
    public float speed;

    public float tilt; //飞船倾斜度随x方向速度系数

    public Boundary boundary; //飞船边界信息

    public GameObject shot;  //子弹对象，这里设成public 在unity中 可以把子弹模板托进来赋值。

    public Transform shotSpawn; //子弹集的初始化位置信息。在unity中，可以把子弹集空对象托进来自动获得其Transform信息。
    public float fireRate; //子弹开火间隔 
    private float nextFireTime; //临时变量，储存判断是否开火的标记，所以这里就不暴露给unity修改了
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //这里很好，不需要子弹集的整个对象，只需要他的位置信息就行了，有效节省了内存。全局变量只包含transform就行了。 现在的问题是，不断の实例化子弹对象，内存回被撑爆的。
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // Vector3 可以直接与float直接相乘，这里可以回顾下c#的运算符重载,或者看下Vector3的源码meta
        //http://www.cnblogs.com/52XF/p/yunsuanfuchognzai.html
        Vector3 v = new Vector3(moveH, 0, moveV);
        rb.velocity = v * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0,
              Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));


        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
