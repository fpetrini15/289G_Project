using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerToInjure : MonoBehaviour
{
     private bool pickUpAllowed;
     public GameObject gun;       
     private bool pointsAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            pickUp();
            if (!pointsAdded)
            {
                ScoreManager.instance.AdddPoints(-20, -20);
                pointsAdded = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
       if (other.CompareTag("Player")){
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
       if (other.CompareTag("Player")){
            pickUpAllowed = false;
        }
    }

    private void pickUp(){
        Destroy(gameObject);
        gun.SetActive(false);
        //hammer.HammerToInjure.enabled = false;
    }
}
