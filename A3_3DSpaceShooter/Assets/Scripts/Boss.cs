using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    public GameObject shieldG;
    public GameObject shield;
    public GameObject smoke;
    public GameObject Bullet;

    public Vector3 verifyValue;
    public Vector3 SGPosOffset;
    public Transform SGL_T;
    public Transform SGR_T;
    public Transform Shield_T;

    public Transform Cannon0;
    public Transform CannonL1;
    public Transform CannonR1;
    public Transform CannonLT;
    public Transform CannonLD;
    public Transform CannonRT;
    public Transform CannonRD;

    //public Transform HPBar;
    //public Slider HPSlider;
    //public Text HP;

    public int healthMax;
    public float gravity;
    public float tilt;
    public float rebootDuration;
    public float fireRate;
    public float speed;

    private int health;
    private GameObject _SGL;
    private GameObject _SGR;
    private GameObject _Shield;
    private Vector3 SGPos;
    private Rigidbody rigidbody;
    private bool reboot;
    private float timer;
    private float nextFire;
    private bool fliper;
    private bool withinField;
    private int direction;
    //private Quaternion rot;
    // Use this for initialization
	void Start () {
        health = healthMax;
        reboot = false;
        fliper = true;
        withinField = false;
        direction = 1;
        _SGL = Instantiate(shieldG, SGL_T);
        _SGR = Instantiate(shieldG, SGR_T);
        _Shield = Instantiate(shield, Shield_T);
        rigidbody = gameObject.GetComponent<Rigidbody>();

        //HPBar.gameObject.SetActive(true);


    }
	
	// Update is called once per frame
	void Update () {
		if(isShieldDown() && reboot == false)
        {
            Destroy(_Shield.gameObject);
            reboot = true;
            timer = 0.0f;
        }

        if(reboot && health > 0)
        {
            if(timer < rebootDuration)
            {
                timer += Time.deltaTime;
            }else
            {
                reboot = false;
                _SGL = Instantiate(shieldG, SGL_T);
                _SGR = Instantiate(shieldG, SGR_T);
                _Shield = Instantiate(shield, Shield_T);
            }
        }

        if (transform.position.y > verifyValue.y && withinField == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime,
                transform.position.z);
        }

        if (transform.position.y <= verifyValue.y && withinField == false)
        {
            withinField = true;
            transform.position = new Vector3(transform.position.x, verifyValue.y, transform.position.z);
        }

        if(withinField)
        {
            checkDirct();
            transform.position = new Vector3(transform.position.x + direction * speed * Time.deltaTime, transform.position.y,
                transform.position.z);

        }


        fire();

        //if (health > 0)
        //{
        //    hpUpdate();
        //}
        //else
        //{
        //    if(HPBar.gameObject.activeInHierarchy == true)
        //    {
        //        HPBar.gameObject.SetActive(false);
        //    }
        //}
	}

    public void Hit()
    {
        if(health > 0)
        {
            health--;
            if(health == 0)
            {
                rigidbody.AddForce(transform.up * - gravity);
                rigidbody.rotation = Quaternion.Euler(new Vector3(rigidbody.velocity.y * tilt, 0.0f, 0.0f));
                Instantiate(smoke, transform);
            }
        }
    }

    public int hp()
    {
        return health;
    }
    public int maxHp()
    {
        return healthMax;
    }

    public float hpUpdate()
    {
        float hpPercentage = (float)health / (float)healthMax;
        //HPSlider.value = hpPercentage;
        //HP.text = "HP " + health;
        return hpPercentage;
    }

    private bool isShieldDown()
    {
        if(_SGL == null && _SGR == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void fire()
    {
        if (health>0 && withinField)
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Bullet, Cannon0);
                Instantiate(Bullet, CannonL1);
                Instantiate(Bullet, CannonR1);
                if(fliper)
                {
                    fliper = false;
                    Instantiate(Bullet, CannonLT);
                    Instantiate(Bullet, CannonRD);
                }else
                {
                    fliper = true;
                    Instantiate(Bullet, CannonRT);
                    Instantiate(Bullet, CannonLD);
                }
            }
        }
    }

    private void checkDirct()
    {
        if (transform.position.x >= verifyValue.x && direction > 0)
        {
            direction = -1;
        }
        if (transform.position.x <= -verifyValue.x && direction < 0)
        {
            direction = 1;
        }
    }
}
