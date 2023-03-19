using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerShot : MonoBehaviour
{
    public GameObject bullet, blood;
    public GameObject lvl3_npc_dialogue;
    public bool shotByBullet = false;
    public AudioSource audioSource_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotByBullet){
            Debug.Log("Shot by bullet");
            GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
            audioSource_.Play();
            Destroy(gameObject);
            Destroy(lvl3_npc_dialogue);
            ScoreManager.instance.PrisonerDestroyed();
            ScoreManager.instance.AdddPoints(-20, -20);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Bullet")){
            shotByBullet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Bullet")){
            shotByBullet = false;
        }
    }
    
}
