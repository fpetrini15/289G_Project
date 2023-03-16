using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHammer : MonoBehaviour
{

    public GameObject blood, guard, fov;
    public GameObject lvl2_door;
    public GameObject finalDoor_;
    public Sprite doorOpen;
    public bool playerIsClose;
    public bool attackingGuard = false;
    private bool pointsAdded = false;

    public AudioSource hitGuard_;
    public AudioSource breakDoor_;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose){
            if(attackingGuard) {
                Debug.Log("Colided");
                GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
                Debug.Log("Instantiated");
                Destroy (guard);
                Destroy (fov);
                hitGuard_.Play();
                lvl2_door.GetComponent<SpriteRenderer>().sprite = doorOpen;
                lvl2_door.GetComponent<BoxCollider2D> ().enabled = false;
                if (!pointsAdded)
                {
                    ScoreManager.instance.AdddPoints(15, -15);
                    pointsAdded = true;
                }
            } else {
                breakDoor_.Play();
                finalDoor_.GetComponent<SpriteRenderer>().sprite = doorOpen;
                finalDoor_.GetComponent<BoxCollider2D> ().enabled = false;
            }
            
        }

    }

    void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Guard")){
            playerIsClose = true;
            attackingGuard = true;
        } else if(other.CompareTag("EndDoor")) {
            Debug.Log("Coliding with final door!");
            playerIsClose = true;
            attackingGuard = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Guard")) {
            playerIsClose = false;
            attackingGuard = false;
        } else if(other.CompareTag("EndDoor")) {
            playerIsClose = false;
            attackingGuard = false;
        }
    }


}
