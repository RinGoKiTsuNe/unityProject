using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDestoryByContact: MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public Slider hpui;
    public int EnemyLife = 30;
    public int scoreValue;
    private GameController gameController;
    // Use this for initialization

    private void Start()
    {
        hpui= Instantiate(hpui);
        hpui.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        hpui.maxValue = hpui.value = EnemyLife;
        hpui.minValue = 0;
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("找不到gameController");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }

       
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
            EnemyLife--;
            hpui.value = EnemyLife;
        }
        if (EnemyLife < 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.AddStore(scoreValue);
            Destroy(gameObject);
            gameController.Win();
        }
        
        

        
    }
}
