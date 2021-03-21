using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class open : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3.5f;
    public GamePlay game;
    public GameObject Open;
    //[SerializeField] Text countdownText;
    void Start()
    {
        game.gamePause();
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            game.gameResume();
            Open.SetActive(false);
        }
    }
}
