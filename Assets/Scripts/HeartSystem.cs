using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public GameObject heartFull_1;
    public GameObject heartEmpty_1;
    public GameObject heartFull_2;
    public GameObject heartEmpty_2;
    public GameObject heartFull_3;
    public GameObject heartEmpty_3;

    public AudioClip deathClip;
    public GameObject deathImage;

    public GameObject spawnWord;

    public AudioSource mainsSource;
    private SceneChanges sceneChanges;

    private void Start()
    {
        sceneChanges = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneChanges>();
        StaticVariables.score = 0;
        StaticVariables.life = StaticVariables.maxLife;
        StaticVariables.currentRules = new List<(string, StaticVariables.RULE)>();
    }

    void Update()
    {
        int life = StaticVariables.life;
        if (life <= 0)
        {
            heartEmpty_1.SetActive(true);
            heartEmpty_2.SetActive(true);
            heartEmpty_3.SetActive(true);
            heartFull_1.SetActive(false);
            heartFull_2.SetActive(false);
            heartFull_3.SetActive(false);
            GameOver();
        }
        else if (life == 1)
        {
            heartEmpty_1.SetActive(false);
            heartEmpty_2.SetActive(true);
            heartEmpty_3.SetActive(true);
            heartFull_1.SetActive(true);
            heartFull_2.SetActive(false);
            heartFull_3.SetActive(false);
        }
        else if (life == 2)
        {
            heartEmpty_1.SetActive(false);
            heartEmpty_2.SetActive(false);
            heartEmpty_3.SetActive(true);
            heartFull_1.SetActive(true);
            heartFull_2.SetActive(true);
            heartFull_3.SetActive(false);
        }
        else if (life == 3)
        {
            heartEmpty_1.SetActive(false);
            heartEmpty_2.SetActive(false);
            heartEmpty_3.SetActive(false);
            heartFull_1.SetActive(true);
            heartFull_2.SetActive(true);
            heartFull_3.SetActive(true);
        }
    }

    private void GameOver()
    {
        mainsSource.Stop();
        spawnWord.gameObject.SetActive(false);
        sceneChanges.GameOverScene();
    }
}
