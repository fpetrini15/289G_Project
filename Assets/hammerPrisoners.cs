using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerPrisoners : MonoBehaviour
{

    private bool pickUpAllowed;
    private bool pointsAdded = false;
    public GameObject blood;

    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            if (!pointsAdded)
            {
                GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
                // audioSource_.Play();
                Destroy(gameObject);
                ScoreManager.instance.AdddPoints(-20, -20);
                pointsAdded = true;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
       if (other.CompareTag("Player")){
            Debug.Log("Collided w prisoner");
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
       if (other.CompareTag("Player")){
            pickUpAllowed = false;
        }
    }
}
