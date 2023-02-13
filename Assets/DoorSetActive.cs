using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour

{
    public Sprite doorOpen;
    public Sprite doorClosed;

    public void OpenDoor() {
        // gameObject.SetActive(false);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
        GetComponent<BoxCollider2D> ().enabled = false;
    }

    public void CloseDoor() {
        // gameObject.SetActive(true);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
        GetComponent<BoxCollider2D> ().enabled = true;
    }
}