using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour {
    public int health;

    public GameObject explosion;

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

    }

    public void Hit()
    {
        if(health > 0)
        {
            health--;
            if(health == 0)
            {
                Instantiate(explosion, gameObject.transform);
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    public int hp()
    {
        return health;
    }
    
    
}
