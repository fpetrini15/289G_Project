using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinalDoorKey : MonoBehaviour
{
    public GameObject door_;
    public Sprite doorOpen;
    public bool playerIsClose;
    public AudioSource audioSource_;
    private bool pointsAdded = false;
    public TMP_Text lvl3_npc_dialogue_8;
    public TMP_Text lvl3_npc_dialogue_10;
    public TMP_Text lvl3_npc_dialogue_11;
    public TMP_Text lvl3_npc_dialogue_14;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            door_.GetComponent<SpriteRenderer>().sprite = doorOpen;
            door_.GetComponent<BoxCollider2D> ().enabled = false;
            lvl3_npc_dialogue_8.text = "We're Free!";
            lvl3_npc_dialogue_10.text = "We're Free!";
            lvl3_npc_dialogue_11.text = "We're Free!";
            lvl3_npc_dialogue_14.text = "We're Free!";
            if (!pointsAdded)
            {
                ScoreManager.instance.AdddPoints(15, 15);
                pointsAdded = true;
            }
            audioSource_.Play();
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
