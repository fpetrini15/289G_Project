// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FollowScript : MonoBehaviour
// {

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     private void FixedUpdate() 
//     {
//         transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform target;
    float speed = 15.0f;
    Vector2 lookDirection;
    const float EPSILON = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (target.position - transform.position).normalized;
        if ((transform.position - target.position).magnitude > EPSILON)
            transform.Translate(lookDirection * Time.deltaTime * speed);
    }
}
