using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalToStart : MonoBehaviour
{
    public void ReStartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
