using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    //public TextMeshProUGUI text;

    public float textSpeed_x = 100;
    public float textSpeed_y = 20;

    public float max_y = 570;
    public float min_y = 266;

    public float min_x = 0;

    public GameObject movingText;
    public AudioClip cutieHurting;
    public AudioClip cutieDeath;

    private GameObject cutie;

    private AudioSource FXsource;

    private void Start()
    {
        FXsource = GameObject.FindGameObjectWithTag("SoundEffectAudioSource").GetComponent<AudioSource>();
        cutie = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // the projectile moves to the left and is centered between [max_y , min_y]
        if (movingText.transform.position.y < min_y)
        {
            movingText.transform.position += new Vector3(-textSpeed_x * Time.deltaTime, +textSpeed_y * Time.deltaTime, 0);
        }
        else if (movingText.transform.position.y > max_y)
        {
            movingText.transform.position += new Vector3(-textSpeed_x * Time.deltaTime, -textSpeed_y * Time.deltaTime, 0);
        }
        else
        {

            movingText.transform.position += new Vector3(-textSpeed_x * Time.deltaTime, 0, 0);
        }

        // If the projectile hits the player
        if (movingText.transform.position.x <= min_x)
        {
            StaticVariables.life -= 1;
            cutie.GetComponent<Animator>().Play("player_hurt");
            if (StaticVariables.life <= 0)
            {
                //FXsource.PlayOneShot(cutieDeath);
            }
            else
            {
                FXsource.PlayOneShot(cutieHurting);
            }
            
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
            foreach (GameObject projectile in projectiles)
            {
                Destroy(projectile.gameObject);
            }
        }
    }
}
