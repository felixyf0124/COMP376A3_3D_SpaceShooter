using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {

    private Rigidbody _player;
    private Quaternion rotaion;
	// Use this for initialization
	void Start () {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            _player = playerObject.GetComponent<Rigidbody>();
        }

        rotaion = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (_player != null)
        {
            Vector3 direction = new Vector3(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y, _player.transform.position.z - transform.position.z);

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        }else
        {
            transform.rotation = rotaion;
        }


    }
}
