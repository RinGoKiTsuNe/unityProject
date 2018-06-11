using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float firstShotTIme = 2.0f;
    public GameObject enemyBolt;
    public GameObject enemyBolt2;
    public Transform enemyShotSpawn;

    public float spawn=1;
    // Use this for initialization
    void Start () {
        StartCoroutine(Shot1());
    }
	


    IEnumerator Shot1()
    {
        while (true)
        {
            yield return new WaitForSeconds(firstShotTIme);

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 360; i += 10)
                {

                    Instantiate(enemyBolt, enemyShotSpawn.position, Quaternion.Euler(0, (float)i, 0));
                }
                spawn = j;
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(5f);
            StartCoroutine(Shot2());
            yield return new WaitForSeconds(8f);
        } 

      

        
    }

     IEnumerator Shot2()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 360; i += 10)
            {

                Instantiate(enemyBolt2, enemyShotSpawn.position, Quaternion.Euler(0, (float)i, 0));
            }
            spawn = j;
            yield return new WaitForSeconds(0.5f);
        }


        




    }
}
