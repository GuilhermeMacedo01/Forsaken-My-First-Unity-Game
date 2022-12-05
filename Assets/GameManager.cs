using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public void GameOver(){

        if(gameEnded == false){
         gameEnded = true;
         Debug.Log("GAME OVER");
         //Restart Game
         Invoke("Restart",2f);
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
