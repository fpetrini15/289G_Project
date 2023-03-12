using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGuard : MonoBehaviour
{
    public GameObject bullet, fov;
    public bool shotByBullet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotByBullet){
            Debug.Log("Shot by bullet");
            Destroy(fov);
            Destroy(gameObject);
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
