using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MyGameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    private Health healthPlayer;

   
   


    public enum GameStates
    {
        Playing,
        GameOver
    }

    public GameStates gameState = GameStates.Playing; 

    // Start is called before the first frame update
    void Start()
    {

        gameOverCanvas.SetActive(false);
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        healthPlayer = player.GetComponent<Health>(); 

 
    }

    // Update is called once per frame
    void Update()
    {
        
       // cam.transform.position = player.transform.position + new Vector3(0, 10, 0);

        switch (gameState)
        {
            case GameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);

                }
                break;

        }
    }
}
