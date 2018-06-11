using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bolt2 : MonoBehaviour {

    public float speed = 1f;
    public float rotationspeed = 1f;
    public float flyTime = 1.5f;
    public float spawnTime = 0.25f;
    private GameObject enemyGameobject;
    private Enemy enemy;
    private Rigidbody rb;
    private float delt;
    private Vector3 direction;
    private Vector3 EulerAngleVelocity;

    private float t;
	// Use this for initialization
	void Start () {
        //enemyGameobject = GameObject.FindGameObjectWithTag("Enemy");
        //if (enemyGameobject == null)
        //{
        //    Debug.Log("找不到enemyGameobject");
        //}
        //enemy = enemyGameobject.GetComponent<Enemy>();//得到波次变量
        //if (enemyGameobject == null)
        //{
        //    Debug.Log("找不到enemy");
        //}
        //flyTime = flyTime - spawnTime * enemy.spawn;//确定飞行时间
        t = Time.time;
        rb = GetComponent<Rigidbody>();
       
        EulerAngleVelocity = new Vector3(0, rotationspeed, 0);
    }
	
	// Update is called once per frame
	void Update () {
        delt = Time.time - t;

        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.velocity = transform.forward * speed;


    }
}
