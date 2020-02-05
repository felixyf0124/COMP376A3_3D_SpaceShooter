using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitGrd : MonoBehaviour {

    public GameObject playerExplosion;
    public Player _player;

    private GameController gameController;

    public CameraShake cShakeEffect;


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

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Ground")
        {
            _player.Damaged();
            gameController.UpdateLevel(_player);
            StartCoroutine(cShakeEffect.CShake());
            int lv = _player.checkCurrentLvl();
            if (lv == 0)
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);

                gameController.GameOver();
                Destroy(gameObject);
            }
        }
    }
}
