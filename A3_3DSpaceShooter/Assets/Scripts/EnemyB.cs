using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour {

    [SerializeField]
    float FireStartDistance;

    [SerializeField]
    float Speed;

    [SerializeField]
    float SpeedHorizontal;

    
    [SerializeField]
    float Amplitude;

    [SerializeField]
    float ShrinkX;

    [SerializeField]
    float ShrinkZ;

    [SerializeField]
    float AttackArea;

    [SerializeField]
    float FireRate;
    float NextFire;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    Transform Cannon;

    private GameController gameController;
    //private bool isTheLast;
    private float minX;
    private float maxX;
    private int step;
    private float offset;
    private bool stay;
    private float stayPos;

    float x, z;
    Vector3 pos;
    float lastMoment;
    int direction;
    

    Rigidbody _rigidbody;
    //GameObject player;
    //Rigidbody2D pBody;

    // Use this for initialization
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


        step = 1;
        _rigidbody = GetComponent<Rigidbody>();
        //minX = rigidbody.position.x - AttackArea;
        //maxX = rigidbody.position.x + AttackArea;
        lastMoment = Time.time;
        
        if (_rigidbody.position.x >= 0)
        {
            direction = -1;
        }
        if (_rigidbody.position.x < 0 )
        {
            direction = 1;
        }
        z = transform.position.z;
        offset = (Mathf.Abs(transform.position.x) - Amplitude) * direction;

        //_rigidbody.velocity = - transform.forward * Speed;
        
        Update();


    }


    void Update()
    {
        
        if (!stay)
        {
            checkDirect();
            if (step == 3 && transform.position.x >= - offset)
            {
                x =  - offset;
                transform.position = new Vector3(x, transform.position.y, z);
                stay = true;
            }
            else
            {
                x = direction * SpeedHorizontal * Time.deltaTime;
                transform.position = new Vector3(transform.position.x + x, transform.position.y, z);
            }
        }
        
        //rigidbody.position = new Vector2(x, rigidbody.position.y);

        

        


        if (atkAvailable() && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Bullet, Cannon.position, Cannon.rotation);
            //GameObject bulletObj = Instantiate(shot, cannon.position, cannon.rotation);
            //Bullet bullet = bulletObj.GetComponent<Bullet>();
            //FireSound.Play();

        }
    }

    

    //public void limitation(float _minX, float _maxX)
    //{
    //    minX = _minX;
    //    maxX = _maxX;
    //}

    private bool atkAvailable()
    {
        if (_rigidbody.position.x < maxX &&
            _rigidbody.position.x > minX &&
           step > 1
            )
        {
            return true;
        }
        else
            return false;



    }

    private void checkDirect()
    {
        if (step == 1)
        {
            if (transform.position.x >= Amplitude && direction > 0)
            {
                direction = -1;
                step = 2;
                maxX = Amplitude;
                minX = -Amplitude;
                z = transform.position.z - ShrinkZ;
            }
            if (transform.position.x <= -Amplitude && direction < 0)
            {
                direction = 1;
                step = 2;
                maxX = Amplitude;
                minX = -Amplitude;
                z = transform.position.z - ShrinkZ;

            }
        }
        if (step == 2)
        {
            if (transform.position.x >= (Amplitude - ShrinkX) && direction > 0)
            {
                direction = -1;
                step = 3;
                maxX = (Amplitude - ShrinkX);
                minX = -(Amplitude - ShrinkX);
                z = transform.position.z - 2.0f * ShrinkZ;

            }
            if (transform.position.x <= -(Amplitude - ShrinkX) && direction < 0)
            {
                direction = 1;
                step = 3;
                maxX = (Amplitude - ShrinkX);
                minX = -(Amplitude - ShrinkX);
                z = transform.position.z - 2.0f * ShrinkZ;
            }
        }
        if (step == 3)
        {
            if (transform.position.x >= (Amplitude - 2 * ShrinkX) && direction > 0)
            {
                direction = -1;
                maxX = (Amplitude - 2 * ShrinkX);
                minX = -(Amplitude - 2 * ShrinkX);

            }
            if (transform.position.x <= -(Amplitude - 2 * ShrinkX) && direction < 0)
            {
                direction = 1;
                maxX = (Amplitude - 2 * ShrinkX);
                minX = -(Amplitude - 2 * ShrinkX);
            }
        }
    }


}
