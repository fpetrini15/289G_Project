using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToStart : MonoBehaviour
{
    public void ReStartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
