using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_G_DBC : MonoBehaviour {

    public GameObject Hit;
    public ShieldGenerator SG;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Player")
        {
            if (SG.hp() > 0)
            {
                Instantiate(Hit, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                SG.Hit();
            }
        }
    }
}
