using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockPick : MonoBehaviour
{
    public GameObject lvl2_door;
    public GameObject NPC3_cell_door;
    public GameObject NPC4_cell_door;
    public GameObject NPC5_cell_door;
    public GameObject NPC5_cell_door_2;
    public Sprite doorOpen;
    public TMP_Text lock_pick_guy_dialogue;
    public bool playerIsClose;
    private bool pointsAdded = false;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            lvl2_door.GetComponent<SpriteRenderer>().sprite = doorOpen;
            lvl2_door.GetComponent<BoxCollider2D> ().enabled = false;
            NPC3_cell_door.SetActive(false);
            NPC4_cell_door.SetActive(false);
            NPC5_cell_door.SetActive(false);
            NPC5_cell_door_2.SetActive(false);
            lock_pick_guy_dialogue.text = "We're Free!";
            if (!pointsAdded)
            {
                ScoreManager.instance.AdddPoints(15, 15);
                pointsAdded = true;
            }
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
