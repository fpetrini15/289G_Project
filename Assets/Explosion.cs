using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool playerIsClose;
    private bool pointsAdded = false;

    // Start is called before the first frame update
    // void Start()
    // {
    // }

    // Update is called once per frameee
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            explosionNPC1.SetActive(true);
            explosionDoor.SetActive(true);
            explosionNPC2.SetActive(true);
            // Debug.Log("kaboom");
            door.SetActive(false);
            NPC1.SetActive(false);
            NPC2.SetActive(false);
            key.SetActive(false);
            NPC1_dialogue_panel.SetActive(false);
            NPC2_dialogue_panel.SetActive(false);
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
