using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public bool playerIsClose;

    // Start is called before the first frame update
    // void Start()
    // {
    // }

    // Update is called once per frameee
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            explosion.SetActive(true);
            Debug.Log("kaboom");
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
            explosion.SetActive(false);
        }
    }
}
