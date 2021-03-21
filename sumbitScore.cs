using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sumbitScore : MonoBehaviour
{
    public InputField inputField;
    public GamePlay game;
    public HighScore highscore;
    string input;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    public void sendInput()
    {
        int front = game.getTimeLeft()/60;
        int back = game.getTimeLeft()%60;
        string time;
        if (back < 10)
        {
            time = front.ToString() + ".0" + back.ToString();
        }
        else
        {
            time = front.ToString() + "." + back.ToString();
            
        }
        highscore.AddHighscoreEntry(getInputField(), time, game.getScore());
    }
    
    public string getInputField(){
        input = inputField.text;
        return input;
    }

}
