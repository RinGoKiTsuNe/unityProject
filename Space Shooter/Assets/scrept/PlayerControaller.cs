using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControaller : MonoBehaviour {
    public float xmin, xmax, zmin, zmax;
    public const float speed = 10;
    public float tilt=-60;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private float myspeed;
    private AudioSource audio;
    private Rigidbody rb;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        myspeed = speed;


    }


    void Update()
    {
        
        
        Shot();

    }

    void FixedUpdate()
    {
        myspeed = speed;
        if (Input.GetButton("Speedchange"))
        {
           
            myspeed = speed / 4;
           
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity=movement*myspeed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xmin, xmax),
            0.0f,
            Mathf.Clamp(rb.position.z, zmin, zmax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, moveHorizontal*tilt);
        

    }


    void Shot()
    {
        
        if (Input.GetButton("Fire1") &&Time.time>nextFire)
        {

            nextFire =Time.time+fireRate;

            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            
            audio.Play(); 
        }

    }
}
