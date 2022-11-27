using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoWrapper : MonoBehaviour
{
    //public UI UI;

    public GameTimer GameTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        Game.Initiliaze(/* UI, */ GameTimer);
        
        //remove this line whenever you add the start button
        Game.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.GameJustEnded())
        {
            Game.EndGame();
        }
    }

    /*
     public void StartGame()
    {
        Game.StartGame();
    }
    */
}