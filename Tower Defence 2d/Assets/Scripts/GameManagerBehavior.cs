using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManagerBehavior : MonoBehaviour {

    public Text waveLable;
    public Text nextWave;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public bool gameOver = false;

    public void Start()
    {
        Gold = 1000;
        Wave = 0;
        Health = 5;

    }

    public Text goldLabel;

    private int gold;
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }
    private int wave;
    public int Wave
    {
        get { return wave;  }
        set
        {
            wave = value;
            if (!gameOver && wave > 0)
            {
                nextWave.GetComponentInParent<Text>().enabled = true;
            }
            waveLable.text = "Wave: " + (wave + 1);
            Invoke("nextWaveDelay", 2);
        }

    }
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            //1 
            if (value < health)
            {
               //  Camera.main.GetComponent<CameraShake>().Shake();
            }
            //2
            health = value;
            healthLabel.text = "Health: " + health;
            //3
            if (health <=0 && !gameOver)
            {
                gameOver = true;
              //  GameObject gameOverText = GameObject.FindGameObjectsWithTag("GameOver");
              //  gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
            //4
            for (int i =0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                } else  {
                    healthIndicator[i].SetActive(false);
                }
            }
       }
    }
    public void nextWaveDelay()
    {
        nextWave.GetComponentInParent<Text>().enabled = false;
    }
}
