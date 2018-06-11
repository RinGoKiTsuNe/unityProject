using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDestore : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    // Use this for initialization

    private void Start()
    {
       GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
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
        if (other.tag == "Boundary"|| other.tag == "Enemy")
        {
            return;
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        
            
    }
}
