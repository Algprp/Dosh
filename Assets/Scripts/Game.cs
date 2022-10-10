using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   

    public enum State
    {
        Playing,
        Won,
        Lost,
    }
    public State Currentstate { get; private set; }
    

    public void OnPlayerReachFinish()
    {
        if (Currentstate != State.Playing) return;
        Currentstate = State.Won;
        
       
        Debug.Log("Game Won!");
      
    }
    
}
