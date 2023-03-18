using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Player finished game!");
            changeToFinalScreen();
        }
    }

    public void changeToFinalScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
