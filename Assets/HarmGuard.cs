using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmGuard : MonoBehaviour
{

    public GameObject blood, guard, fov;
    public bool playerIsClose;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose){
            Debug.Log("Colided");
            GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log("Instantiated");
            Destroy (guard);
            Destroy (fov);
        }

    }

    void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag("Guard")){
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Guard"))
        {
            playerIsClose = false;
        }
    }


}
