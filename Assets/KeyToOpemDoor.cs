using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyToOpemDoor : MonoBehaviour
{
    public GameObject doorzies;
    public GameObject skullzies;
    public GameObject NPC1_cell_door;
    public GameObject NPC2_cell_door;
    public Sprite doorOpen;
    public TMP_Text npc1_dialogue;
    public TMP_Text npc2_dialogue;
    public TMP_Text lvl2_npc_dialogue;
    public TMP_Text lvl2_npc_dialogue_2;
    public string[] dialogue_options = new string[5];
    private string selected_dialogue;
    private string selected_dialogue_2;
    public bool playerIsClose;
    private bool pointsAdded = false;
    public AudioSource audioSource_;

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
            NPC1_cell_door.SetActive(false);
            NPC2_cell_door.SetActive(false);
            npc1_dialogue.text = "We're Free!";
            npc2_dialogue.text = "We're Free!";
            int index = Random.Range(0, dialogue_options.Length);
            int index_2 = (index + 1) % 5;
            selected_dialogue = dialogue_options[index];
            selected_dialogue_2 = dialogue_options[index_2];
            lvl2_npc_dialogue.text = selected_dialogue;
            lvl2_npc_dialogue_2.text = selected_dialogue_2;
            audioSource_.Play();
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
