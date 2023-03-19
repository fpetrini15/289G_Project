using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateLevel3 : MonoBehaviour
{
    public GameObject finalDoorKey_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(ScoreManager.instance.GetSanityScore() > 0) { // Clean runs are rewarded
                Debug.Log("Set key active");
                finalDoorKey_.SetActive(true);
            } else {
                Debug.Log("Set key inactive");
                finalDoorKey_.SetActive(false);
            }
        }
    }
}
