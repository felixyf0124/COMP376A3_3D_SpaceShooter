using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBHitGr : MonoBehaviour {

    public GameObject explosion;
    
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Ground")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            //gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
