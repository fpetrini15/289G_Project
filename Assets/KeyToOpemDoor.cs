using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyToOpemDoor : MonoBehaviour
{
    public GameObject doorzies;
    public GameObject skullzies;
    public Sprite doorOpen;
    public TMP_Text npc1_dialogue;
    public TMP_Text npc2_dialogue;
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
            doorzies.GetComponent<SpriteRenderer>().sprite = doorOpen;
            doorzies.GetComponent<BoxCollider2D> ().enabled = false;
            skullzies.SetActive(false);
            npc1_dialogue.text = "We're Free!";
            npc2_dialogue.text = "We're Free!";
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
            // explosion.SetActive(false);
        }
    }
}
