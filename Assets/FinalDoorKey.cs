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
