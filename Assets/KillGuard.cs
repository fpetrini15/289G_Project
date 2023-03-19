using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGuard : MonoBehaviour
{
    public GameObject bullet, fov, blood;
    public GameObject lvl2_door;
    public GameObject endDoorKey_;
    public Sprite doorOpen;
    public bool shotByBullet = false;
    private bool pointsAdded = false;
    public AudioSource audioSource_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotByBullet){
            GameObject bloodIns = Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log("Shot by bullet");
            audioSource_.Play();
            Destroy(fov);
            Destroy(gameObject);
            lvl2_door.GetComponent<SpriteRenderer>().sprite = doorOpen;
            lvl2_door.GetComponent<BoxCollider2D> ().enabled = false;
            if (!pointsAdded)
            {
                ScoreManager.instance.AdddPoints(20, -15);
                pointsAdded = true;
            }
            if(ScoreManager.instance.GetSanityScore() <= 0) { // clean runs are rewarded
                endDoorKey_.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Bullet")){
                shotByBullet = true;
            }
        }

    private void OnTriggerExit2D(Collider2D other){
            if(other.CompareTag("Bullet")){
                shotByBullet = false;
            }
        }
    
}
