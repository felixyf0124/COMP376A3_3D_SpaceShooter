using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyAWaveSetting
{
    public int NoOfShips;

    public GameObject TypeOfShip;

    public float hDistance;

    public float vDistance;

    public float NextShipSec;

    public Vector3 spawnValues;
}

[System.Serializable]
public class EnemyBWaveSetting
{
    public int NoOfShips;

    public GameObject TypeOfShip;

    public float NextShipSec;

    public Vector3 spawnValues;

    public float posOffset;

    //public float FireHoldArea;
}

[System.Serializable]
public class EnemyBossSetting
{
    public GameObject BossShip;

    public Vector3 spawnValues;


}

public class GameController : MonoBehaviour {

    [SerializeField]
    EnemyAWaveSetting EnemyGroupA;
    
    [SerializeField]
    EnemyBWaveSetting EnemyGroupB;

    [SerializeField]
    EnemyBossSetting Boss;

    [SerializeField]
    Player player;

    [SerializeField]
    GameObject powerUp;

    [SerializeField]
    int waves;

    [SerializeField]
    float NextSpawnWaveSec;

    [SerializeField]
    float CheckFrequencySec;

    public Text ScoreText;

    //public Text RestartText;

    public Text GameOverText;

    public Text PlayerLv;

    public Text BossHP;
    public Transform HPBar;
    public Slider HPSlider;

    private int Score;
    private int wCounter;
    private bool isA;
    private bool Looping;
    private bool nextSpawn;
    private bool gameOver;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    
    public List<int> killedAs;
    public List<int> killedBs;
    

    // Use this for initialization
    void Start () {

        isA = true;
        Looping = true;
        nextSpawn = true;
        gameOver = false;
        spawnRotation = Quaternion.identity;
        Time.timeScale = 1;
        HPBar.gameObject.SetActive(false);
        //Update();
    }
	
	// Update is called once per frame
	void Update () {



        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.LoadLevel("MainMenu");
        //}
        if (Looping == true)
        {
            StartCoroutine(SpawnWaves());
        }

        if (gameOver)
        {
            if (player.checkCurrentLvl() == 0)
            {
                GameOverText.text = "Game Over";
            }
            else
            {
                GameOverText.text = "You Win";
            }
        }
    }


    IEnumerator SpawnWaves()
    {
        
        //currentScrollSpeed = bgScrollingSpeed;

        while (Looping)
        {
            Looping = false;

            wCounter = 0;
            while (wCounter < waves)
            {
                if (gameOver)
                {
                    break;
                }

                if (isA)
                {
                    nextSpawn = false;
                    
                    int leader = v_leaderGenerator();
                    float positionX = Random.Range(-EnemyGroupA.spawnValues.x, EnemyGroupA.spawnValues.x);
                    float positionY = Random.Range(2.0f, EnemyGroupA.spawnValues.y);
                    float positionZ = EnemyGroupA.spawnValues.z;
                    float lx, rx, ly, ry;
                    int left, right;
                    left = leader - 1;
                    right = leader + 1;

                    spawnPosition = new Vector3(positionX, positionY, positionZ);
                    GameObject instA = Instantiate(EnemyGroupA.TypeOfShip, spawnPosition, spawnRotation);
                    
                    while (left >= 0 || right < EnemyGroupA.NoOfShips)
                    {
                        yield return new WaitForSeconds(EnemyGroupA.NextShipSec);

                        if (left >= 0)
                        {
                            lx = positionX + (leader - left) * EnemyGroupA.hDistance;
                            ly = positionY + (leader - left) * EnemyGroupA.vDistance;
                            spawnPosition = new Vector3(lx, ly, positionZ);
                            GameObject instAL = Instantiate(EnemyGroupA.TypeOfShip, spawnPosition, spawnRotation);
                            
                        }
                        if (right < EnemyGroupA.NoOfShips)
                        {
                            rx = positionX + (leader - right) * EnemyGroupA.hDistance;
                            ry = positionY - (leader - right) * EnemyGroupA.vDistance;
                            spawnPosition = new Vector3(rx, ry, positionZ);
                            GameObject instAR = Instantiate(EnemyGroupA.TypeOfShip, spawnPosition, spawnRotation);
                           
                        }

                        left--;
                        right++;
                    }

                    //set next spawn for enemy B
                    isA = !isA;

                    // check if current spawn all dead

                    while(!nextSpawn)
                    {
                        yield return new WaitForSeconds(CheckFrequencySec);
                    }
                   
                    yield return new WaitForSeconds(NextSpawnWaveSec);
                }
                else
                {
                    nextSpawn = false;
                    int direction = Random.Range(0, 1);
                    float positionX;
                    if (direction == 1)
                        positionX = EnemyGroupB.spawnValues.x + EnemyGroupB.NoOfShips / 2 * EnemyGroupB.posOffset;
                    else
                        positionX = -EnemyGroupB.spawnValues.x + EnemyGroupB.NoOfShips / 2 * EnemyGroupB.posOffset;
                    float positionY = Random.Range(3.0f, EnemyGroupB.spawnValues.y);
                    float positionZ = EnemyGroupB.spawnValues.z;

                    for (int i = 0; i < EnemyGroupB.NoOfShips; i++)
                    {
                        spawnPosition = new Vector3(positionX - i * EnemyGroupB.posOffset, positionY, positionZ);
                        //Instantiate(EnemyGroupB.TypeOfShip, spawnPosition, spawnRotation);
                        GameObject instB = Instantiate(EnemyGroupB.TypeOfShip, spawnPosition, spawnRotation);
                       
                    }

                    //set next spawn for enemy A
                    isA = !isA;

                    // check if current spawn all dead

                    while (!nextSpawn)
                    {
                        yield return new WaitForSeconds(CheckFrequencySec);
                    }

                    yield return new WaitForSeconds(NextSpawnWaveSec);
                }

                wCounter++;
                if (gameOver)
                {
                    break;
                }
            }
            if (gameOver)
            {
                break;
            }
            if (wCounter == waves && nextSpawn)
            {
                nextSpawn = false;

                spawnPosition = new Vector3(Boss.spawnValues.x, Boss.spawnValues.y, Boss.spawnValues.z);
                Instantiate(Boss.BossShip, spawnPosition, spawnRotation);
                HPBar.gameObject.SetActive(true);


            }

            //if (gameOver)
            //{
            //    restartText.text = "Press 'R' to Restart";
            //    restart = true;
            //    break;
            //}


            //yield return new WaitForSeconds(bossComing);

            //spawnPosition = new Vector2(0.0f, spawnPosBoss);
            //Instantiate(bossA, spawnPosition, spawnRotation);
            //isBossFight = true;



        }
    }


    public bool checkWaveA(int id)
    {
        if (killedAs.Contains(id))
            return false;
        else
        {
            killedAs.Add(id);
            
            return true;
        }
        
    }
    
    public bool checkWaveKillA()
    {
        if (killedAs.Count == EnemyGroupA.NoOfShips)
        {
            
            killedAs.Clear();
            nextSpawn = true;
            return true;
        }
        return false;
    }

    public bool checkWaveB(int id)
    {
        if (killedBs.Contains(id))
            return false;
        else
        {
            killedBs.Add(id);
            
            return true;
        }
       
    }

    public bool checkWaveKillB()
    {
        if (killedBs.Count == EnemyGroupB.NoOfShips)
        {
            killedBs.Clear();
            nextSpawn = true;
            return true;
        }
        return false;
    }

    public void dropItem(Transform trans)
    {
        Instantiate(powerUp, trans.position, trans.rotation);
    }


    public void AddScore(int reward)
    {
        Score += reward;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    public void UpdateLevel(Player _p)
    {
        PlayerLv.text = "Lv. " + _p.checkCurrentLvl();
    }

    public void UpdateBossHP(float perCent, int HP)
    {
        if (HP > 0)
        {
            HPSlider.value = perCent;
            BossHP.text = "HP " + HP;
        }
        else
        {
            HPBar.gameObject.SetActive(false);
        }
    }

    public bool isGameOver()
    {
        
        return gameOver;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    
    private int v_leaderGenerator()
    {

        int leaderNo = Random.Range(1, 4);
        return leaderNo;
    }

}
