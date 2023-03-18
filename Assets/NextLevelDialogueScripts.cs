using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextLevelDialogueScripts : MonoBehaviour
{
    public GameObject lvl2_door;
    public TMP_Text lvl3_npc_dialogue_1;
    public TMP_Text lvl3_npc_dialogue_2;
    public TMP_Text lvl3_npc_dialogue_3;
    private bool doorOpened = false;
    public string[] dialogue_options = new string[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lvl2_door.GetComponent<BoxCollider2D> ().enabled == false && !doorOpened)
        {
            Debug.Log("Open Sesame");
            int sanityScore = ScoreManager.instance.GetSanityScore();
            int reputation = ScoreManager.instance.GetReputationScore();
            // if (sanityScore <= -40)
            // {

            // }
            doorOpened = true;
        }*/
        
    }
}
