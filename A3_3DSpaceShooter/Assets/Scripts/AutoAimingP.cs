using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoAimingP : MonoBehaviour {

    public GameObject cannon0;
    public GameObject cannonL1;
    public GameObject cannonR1;
    public GameObject cannonL2;
    public GameObject cannonR2;
    public GameObject cannonL3;
    public GameObject cannonR3;

    private GameObject[] enemies;
    private Vector3[] Positions;
    private int target;

    // Use this for initialization
    void Start () {
        target = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ScanEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        Positions = new Vector3[enemies.Length];
        
    }


    void checkPos()
    {
        for (int i=0;i<enemies.Length;i++)
        {
            Positions[i] = enemies[i].transform.position;
        }
    }
    void checkTarget()
    {
        float[] _Distances = new float[enemies.Length];

        for (int i = 0; i<enemies.Length; i++)
        {
            _Distances[i] = (enemies[i].transform.position - this.transform.position).magnitude;

        }



    }
}
