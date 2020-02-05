using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVCamera : MonoBehaviour {


    private Rigidbody _player;
    

    
    public Vector3 Offset;

    // Use this for initialization
    void Start () {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		
        if (playerObject != null)
        {
            _player = playerObject.GetComponent<Rigidbody>();
        }

      

       // Update();
	}
	
	// Update is called once per frame
	void Update () {
        if (_player != null)
        {
            transform.position = new Vector3(_player.transform.position.x + Offset.x, _player.transform.position.y + Offset.y, _player.transform.position.z + Offset.z);

        }
	}
}
