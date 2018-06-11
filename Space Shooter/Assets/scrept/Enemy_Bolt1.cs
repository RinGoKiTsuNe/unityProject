using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bolt1 : MonoBehaviour {

    public float speed = 0.02f;
    public float flyTime = 1.5f;
    public float spawnTime = 0.25f;
    private GameObject enemyGameobject;
    private Enemy enemy;
    private Rigidbody rb;

    private float t;
	// Use this for initialization
	void Start () {
        enemyGameobject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyGameobject == null)
        {
            Debug.Log("找不到enemyGameobject");
        }
        enemy = enemyGameobject.GetComponent<Enemy>();//得到波次变量
        if (enemyGameobject == null)
        {
            Debug.Log("找不到enemy");
        }
        t = Time.time;
        flyTime = flyTime - spawnTime * enemy.spawn;//确定飞行时间
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward*speed;
    }
	
	// Update is called once per frame
	void Update () {

       
        Debug.Log("spawn" + enemy.spawn);

        if (Time.time - t > flyTime)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
	}
}
