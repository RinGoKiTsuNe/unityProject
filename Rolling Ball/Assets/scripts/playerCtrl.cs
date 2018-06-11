using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerCtrl : MonoBehaviour {

    public Text countText;
    public Text Wintext;
    public float speed=10.0f;

    private int count ;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        Wintext.text="";


    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Debug.Log("1");
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count ==12)
        {
            Wintext.text = "You Win";
        }
    }
}
