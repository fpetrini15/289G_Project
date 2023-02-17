using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToOpemDoor : MonoBehaviour
{
    public GameObject doorzies;
    public Sprite doorOpen;
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
            doorzies.GetComponent<SpriteRenderer>().sprite = doorOpen;
            doorzies.GetComponent<BoxCollider2D> ().enabled = false;
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
