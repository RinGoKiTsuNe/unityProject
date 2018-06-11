using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

   public float Speed = 20;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb=GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
