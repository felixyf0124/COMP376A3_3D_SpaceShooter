using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}



public class Player : MonoBehaviour {

    [SerializeField]
    float mMoveSpeed = 1.2f;

    [SerializeField]
    float DashSpeed;

    [SerializeField]
    float TiltH;

    [SerializeField]
    float TiltV;

    Rigidbody mRigidBody;
    
    public Boundary mBoundary;

    [SerializeField]
    GameObject shot;
    [SerializeField]
    Transform Cannon0;
    [SerializeField]
    Transform CannonL1;
    [SerializeField]
    Transform CannonR1;
    [SerializeField]
    Transform CannonL2;
    [SerializeField]
    Transform CannonR2;
    [SerializeField]
    Transform CannonL3;
    [SerializeField]
    Transform CannonR3;


    [SerializeField]
    float fireRate;
    float nextFire;

    

    public int Level;
    public int maxLevel = 7;
    private int minlv;

    private bool steering;
    private bool yDirectionReverse;
    private int direction;
    //public AudioSource[] Audio[2];

    public AudioSource fireSound;
    public AudioSource Power;
    
    // Use this for initialization
    void Start () {
        mRigidBody = GetComponent<Rigidbody>();

        steering = false;
        yDirectionReverse = false;
        direction = 1;
        //Audio = GetComponents<AudioSource>();
        //fireSound = Audio[0];
        //Power = Audio[1];
        if (Level == 0)
        {
            Level = 1;
        }

        minlv = 0;
        //FixedUpdate();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fireSound.Play();
            fire();
            
            
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            steering = !steering;
           
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            yDirectionReverse = !yDirectionReverse;
            if (yDirectionReverse)
            {
                direction = 1;
            }else
            {
                direction = -1;
            }
            
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, direction * moveVertical);
        mRigidBody.velocity = movement * mMoveSpeed;
        
        
        mRigidBody.position = new Vector2(Mathf.Clamp(mRigidBody.position.x, mBoundary.xMin, mBoundary.xMax),
                                               Mathf.Clamp(mRigidBody.position.y, mBoundary.yMin, mBoundary.yMax));
        if (steering)
        {
            float xR, yR, zR;
            if (mRigidBody.velocity.y == 0)
            {
                xR = 0.0f;
            }
            else
            {
                xR = mRigidBody.velocity.y * direction * -TiltV;
            }
            if (mRigidBody.velocity.x == 0)
            {
                yR = 0.0f;
                zR = 0.0f;
            }
            else
            {
                yR = mRigidBody.velocity.x * direction * TiltH;
                zR = mRigidBody.velocity.x * -TiltH;
            }

            mRigidBody.rotation = Quaternion.Euler(xR, yR, zR);
           
        }else
        {
            float zR;
            if (mRigidBody.velocity.x == 0)
            {
                zR = 0.0f;
            }
            else
            {
                zR = mRigidBody.velocity.x * -TiltH;
            }
            mRigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, zR);

        }

    }

    public void Damaged()
    {
        if (Level > minlv)
        {
            Level--;

        }


    }
    public void Boost()
    {
        if (Level < maxLevel)
        {
            Level++;
            Power.Play();
        }
    }

    

    public int checkCurrentLvl()
    {
        return Level;
    }



    //fire at certain level
    private void fire()
    {
        if (Level == 1)
            Instantiate(shot, Cannon0.position, Cannon0.rotation);
        if (Level == 2)
        {
            Instantiate(shot, CannonL1.position, CannonL1.rotation);
            Instantiate(shot, CannonR1.position, CannonR1.rotation);
        }
        if (Level == 3)
        {
            Instantiate(shot, Cannon0.position, Cannon0.rotation);
            Instantiate(shot, CannonL2.position, CannonL2.rotation);
            Instantiate(shot, CannonR2.position, CannonR2.rotation);
        }
        if (Level == 4)
        {
            Instantiate(shot, CannonL1.position, CannonL1.rotation);
            Instantiate(shot, CannonR1.position, CannonR1.rotation);
            Instantiate(shot, CannonL2.position, CannonL2.rotation);
            Instantiate(shot, CannonR2.position, CannonR2.rotation);
        }
        if (Level == 5)
        {
            Instantiate(shot, Cannon0.position, Cannon0.rotation);
            Instantiate(shot, CannonL1.position, CannonL1.rotation);
            Instantiate(shot, CannonR1.position, CannonR1.rotation);
            Instantiate(shot, CannonL2.position, CannonL2.rotation);
            Instantiate(shot, CannonR2.position, CannonR2.rotation);
        }
        if (Level == 6)
        {
            Instantiate(shot, CannonL1.position, CannonL1.rotation);
            Instantiate(shot, CannonR1.position, CannonR1.rotation);
            Instantiate(shot, CannonL2.position, CannonL2.rotation);
            Instantiate(shot, CannonR2.position, CannonR2.rotation);
            Instantiate(shot, CannonL3.position, CannonL3.rotation);
            Instantiate(shot, CannonR3.position, CannonR3.rotation);
        }
        if (Level == 7)
        {
            Instantiate(shot, Cannon0.position, Cannon0.rotation);
            Instantiate(shot, CannonL1.position, CannonL1.rotation);
            Instantiate(shot, CannonR1.position, CannonR1.rotation);
            Instantiate(shot, CannonL2.position, CannonL2.rotation);
            Instantiate(shot, CannonR2.position, CannonR2.rotation);
            Instantiate(shot, CannonL3.position, CannonL3.rotation);
            Instantiate(shot, CannonR3.position, CannonR3.rotation);
        }
    }

}
