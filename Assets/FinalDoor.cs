using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject bullet;
    public Sprite doorOpen;
    public bool shotByBullet = false;
    public AudioSource audioSource_;
    private int MAX_PRISONERS = 7;
    public GameObject endDoorKey_;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shotByBullet){
            audioSource_.Play();
            this.GetComponent<SpriteRenderer>().sprite = doorOpen;
            this.GetComponent<BoxCollider2D> ().enabled = false;
        }
        if(ScoreManager.instance.GetPrisonerDestroyed() == MAX_PRISONERS) { // all prisoners destroyed
            endDoorKey_.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet") {
            shotByBullet = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet") {
            shotByBullet = false;
        }
    }
}