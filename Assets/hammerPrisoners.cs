using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerPrisoners : MonoBehaviour
{

    private bool pickUpAllowed;
    private bool pointsAdded = false;
    public GameObject blood;
    public GameObject lvl3_npc_dialogue;
    public AudioSource audioSource_;

    void Update()
    {
        if (pickUpAllowed && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))){
            if (!pointsAdded)
            {
                GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
                audioSource_.Play();
                Destroy(gameObject);
                Destroy(lvl3_npc_dialogue);
                ScoreManager.instance.PrisonerDestroyed();
                ScoreManager.instance.AdddPoints(-15, -15);
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
}
