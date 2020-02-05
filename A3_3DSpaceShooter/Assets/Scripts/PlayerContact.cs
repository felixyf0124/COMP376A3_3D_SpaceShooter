using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContact : MonoBehaviour {

    public GameObject playerExplosion;
    public Player player;

    private GameController gameController;

    public CameraShake cShakeEffect;

    public int trigger;

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

        //GameObject player = GameObject.FindWithTag("Player");
        //if (gameControllerObj != null)
        //{
        //    player = GetComponent<Player>();
        //}
        gameController.UpdateLevel(player);
        trigger = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "PowerUp" && this.tag == "Player")
        {


            player.Boost();
            //Power.Play();
            trigger++;
            gameController.UpdateLevel(player);

            Destroy(other.gameObject);


        }else
        if (other.tag == "Enemy" || other.tag == "BulletE" ||
            other.tag == "BossPartAL" || other.tag == "BossPartAR" ||
            other.tag == "BossPartB" || other.tag == "BossPartC" /*|| 
            /*(other.tag == "Bullet" && gameController.isBulletHell)*/)
        {

            if(other.tag == "Bullet" )
            {
                Destroy(other.gameObject);
            }
            
            player.Damaged();
            gameController.UpdateLevel(player);
            StartCoroutine( cShakeEffect.CShake());

            int lv = player.checkCurrentLvl();
            if (lv == 0)
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);

                gameController.GameOver();
                Destroy(gameObject);
            }

        }
    }
    
    
}
