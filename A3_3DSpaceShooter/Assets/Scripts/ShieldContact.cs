using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldContact : MonoBehaviour {

    public GameObject Hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Player")
        {
            Instantiate(Hit, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
               
        }
    }
}
