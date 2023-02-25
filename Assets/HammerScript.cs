using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    private bool pickUpAllowed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            pickUp();
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
    }
}
