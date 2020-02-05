using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    float StayDistance;

    private bool stay;

    Rigidbody _rigidbody;
    // Use this for initialization
    void Start()
    {
        stay = false;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = -transform.forward * speed;
    }

    private void Update()
    {
        
        if(transform.position.z <= StayDistance && stay == false)
        {
            stay = true;
            _rigidbody.velocity = new Vector3 (_rigidbody.velocity.x, _rigidbody.velocity.y, 0.0f);
            //transform.position = new Vector3(transform.position.x, transform.position.y, StayDistance);
        }


    }


    

}
