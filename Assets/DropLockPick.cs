using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropLockPick : MonoBehaviour
{
    public GameObject lockpick;
    public TMP_Text lock_pick_guy_dialogue;
    public bool playerIsClose;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
         {
            lockpick.SetActive(true);
            lock_pick_guy_dialogue.text = "Check for a present by the exit ;)";
         }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
