using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float speed;

    //[SerializeField]
    //Vector2 edge;

    //[SerializeField]
    //int wrapTime;


    //public GameObject Hit;
    //private GameController gameController;



    Rigidbody rigidbody;
	// Use this for initialization
	void Start () {


        //GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        //if (gameControllerObj != null)
        //{
        //    gameController = gameControllerObj.GetComponent<GameController>();
        //}
        //if (gameController == null)
        //{
        //    Debug.Log("Cannot find 'GameController' script.");
        //}

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity =  transform.forward * speed;
        
	}



    //private void Update()
    //{
    //    if(gameController.isBulletHell && wrapTime > 0)
    //    {
    //        if(rigidbody.position.y > edge.y)
    //        {
    //            rigidbody.position = new Vector2(rigidbody.position.x, -edge.y);
    //            wrapTime--;
    //        }

    //        if (rigidbody.position.y < -edge.y)
    //        {
    //            rigidbody.position = new Vector2(rigidbody.position.x, edge.y);
    //            wrapTime--;
    //        }

    //    }
    //}

    

}
