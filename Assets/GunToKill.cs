using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToKill : MonoBehaviour
{
    private bool pickUpAllowed;
    public GameObject hammer;       
    private bool pointsAdded = false;
    public GameObject body;
    public GameObject gun2;
    public GameObject LockPickGuyDialogueBox;
    public GameObject LockPickGuy;  
    ShootScript shootscript;

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
                ScoreManager.instance.AdddPoints(-30, -30);
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
        hammer.SetActive(false);
        gun2.SetActive(true);
        LockPickGuyDialogueBox.SetActive(false);
        LockPickGuy.GetComponent<DropLockPick>().enabled = false;
        //shoot_script = FindObjectOfType<ShootScript>();
        shootscript = GameObject.Find("body").GetComponent<ShootScript>();
        //hammer.HammerToInjure.enabled = false;
    }
}
