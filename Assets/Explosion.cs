using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Explosion : MonoBehaviour
{
    public GameObject explosionDoor;
    public GameObject explosionNPC1;
    public GameObject explosionNPC2;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC1_dialogue_panel;
    public GameObject NPC2_dialogue_panel;
    public GameObject door;
    public GameObject key;
    public GameObject NPC1_cell_door;
    public GameObject NPC2_cell_door;
    public TMP_Text lvl2_npc_dialogue;
    public TMP_Text lvl2_npc_dialogue_2;
    public string[] dialogue_options = new string[5];
    private string selected_dialogue;
    private string selected_dialogue_2;
    public bool playerIsClose;
    private bool pointsAdded = false;
    public AudioSource audioSource_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameee
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            audioSource_.Play();
            explosionNPC1.SetActive(true);
            explosionDoor.SetActive(true);
            explosionNPC2.SetActive(true);
            // Debug.Log("kaboom");
            door.SetActive(false);
            NPC1.SetActive(false);
            NPC2.SetActive(false);
            key.SetActive(false);
            NPC1_cell_door.SetActive(false);
            NPC2_cell_door.SetActive(false);
            NPC1_dialogue_panel.SetActive(false);
            NPC2_dialogue_panel.SetActive(false);
            int index = Random.Range(0, dialogue_options.Length);
            int index_2 = (index + 1) % 5;
            selected_dialogue = dialogue_options[index];
            selected_dialogue_2 = dialogue_options[index_2];
            lvl2_npc_dialogue.text = selected_dialogue;
            lvl2_npc_dialogue_2.text = selected_dialogue_2;
            if (!pointsAdded)
            {
                ScoreManager.instance.AdddPoints(-40, -40);
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
            explosionNPC1.SetActive(false);
            explosionDoor.SetActive(false);
            explosionNPC2.SetActive(false);
        }
    }
}
