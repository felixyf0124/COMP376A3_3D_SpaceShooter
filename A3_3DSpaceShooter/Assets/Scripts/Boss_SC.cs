using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SC : MonoBehaviour {

    public GameObject Hit;
    //public GameObject explosion;
    //public GameObject Boss;
    public Boss boss;
    

    public int scoreValue;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
        gameController.UpdateBossHP(boss.hpUpdate(), boss.hp());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Instantiate(Hit, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            if (boss.hp() > 0)
            {
                
                boss.Hit();
                gameController.UpdateBossHP(boss.hpUpdate(), boss.hp());
                if(boss.hp() == 0)
                {
                    gameController.AddScore(scoreValue);
                    //gameController.dropItem(gameObject.transform);
                }
            }
        }
        

    }

   


}
