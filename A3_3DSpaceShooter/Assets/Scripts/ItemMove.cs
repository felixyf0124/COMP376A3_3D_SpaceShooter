using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour {

    [SerializeField]
    float PosZ;

    [SerializeField]
    float Speed;
    
    [SerializeField]
    Vector2 MoveArea;

    //private bool isTheLast;
    private float X;
    private float Y;
    private float Z;
   
    Vector3 pos;
    
    Vector2 direction;
    
    float dist;
    
    float lastMoment;

    // Use this for initialization
    void Start () {
        //rigidbody = GetComponent<Rigidbody2D>();
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        pos.z = transform.position.z;
        dist = X - 0.0f;
        //lastMoment = Time.time;
        
        if (pos.x >= 0)
        {
            direction.x = 1;
        }
        if (pos.x < 0)
        {
            direction.x = -1;
        }
        if (pos.y >= MoveArea.y / 2.0f)
        {
            direction.y = -1;
        }
        if (pos.y < MoveArea.y / 2.0f)
        {
            direction.y = 1;
        }
        //pos = transform.position;
        //angOffset = Mathf.Abs(Mathf.Asin(dist / MoveArea.x));
        //rigidbody.velocity = -transform.up * Speed* direction.y;
        Update();
    }
	
	// Update is called once per frame
	void Update () {

       
        Y =  direction.y*Speed * Time.deltaTime;
        X = direction.x * Speed * Time.deltaTime;
        if (transform.position.z > PosZ)
        {
            Z = transform.position.z - Speed * Time.deltaTime;

        }
        else
        {
            Z = transform.position.z;
        }


        checkDirect();
        
        transform.position = new Vector3(transform.position.x + X, transform.position.y + Y, Z);
        
    }

    private void checkDirect()
    {
        if(transform.position.y >= MoveArea.y && direction.y >= 0)
        {

            direction.y = -1;

        }
        if(transform.position.y <=0.5f && direction.y < 0)
        {
            direction.y = 1;
        }
        if (transform.position.x >= MoveArea.x && direction.x >= 0)
        {

            direction.x = -1;

        }
        if (transform.position.x < -MoveArea.x && direction.x < 0)
        {
            direction.x = 1;
        }
    }

    
    
}
