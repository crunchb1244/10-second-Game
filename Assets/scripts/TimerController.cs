using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    float timer = 0.0f;
    float gameTimer = 10;

    public ProjectileManager projectileManager;

    public Text winText;

    public Text loseText;

    public AudioSource winSound;

    public AudioSource loseSound;
    public PlayerController playerController;

    public bool hasLost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>2)
        {
            gameTimer -= Time.deltaTime;
           timerText.text = gameTimer.ToString("0");
        }

        if(gameTimer<0 && hasLost==false)
        {
            projectileManager.isOn = false;
            Destroy(timerText.gameObject);
            winText.gameObject.SetActive(true);
            winSound.Play();
        }

        if(hasLost==true)
        {              
            projectileManager.isOn = false;
            Destroy(timerText.gameObject);
            loseText.gameObject.SetActive(true);
            loseSound.Play();
        }

    }
}