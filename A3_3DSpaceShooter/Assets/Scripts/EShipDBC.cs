using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShipDBC : MonoBehaviour {

    
    public GameObject Smoke;
    
    public GameObject playerExplosion;

    public GameObject Hit;

    public float Gravity;

    public int scoreValue;

    private GameController gameController;
    private bool forceAdded;

    public int enemyType;


    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if(gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }

        forceAdded = false;

    }


    void OnTriggerEnter(Collider other)
    {
        


        if (other.tag == "Bullet" || other.tag == "Player" )
        {
                Instantiate(Hit, other.transform.position, other.transform.rotation);
                Instantiate(Smoke, transform);

            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            if (forceAdded == false)
            {
                forceAdded = true;
                rigidbody.AddForce(transform.up * -Gravity);
            }
            
            int id = gameObject.GetInstanceID();

            gameController.AddScore(scoreValue);
            if (enemyType == 1)
            {
                if (gameController.checkWaveA(id))
                {
                    if (gameController.checkWaveKillA())
                    {
                        gameController.AddScore(scoreValue * 5);
                        gameController.dropItem(gameObject.transform);
                    }
                }
                
            }
            if (enemyType == 2)
            {
                if (gameController.checkWaveB(id))
                {
                    if (gameController.checkWaveKillB())
                    {
                        gameController.AddScore(scoreValue * 5);
                        gameController.dropItem(gameObject.transform);
                    }
                }
                
            }
            if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);

            }
            //Destroy(gameObject);
           
            
            
        }
    }
}
