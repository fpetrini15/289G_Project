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
    public TMP_Text lvl3_npc_dialogue_4;
    private bool doorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lvl2_door.GetComponent<BoxCollider2D> ().enabled == false && !doorOpened)
        {
            Debug.Log("Open Sesame");
            int sanityScore = ScoreManager.instance.GetSanityScore();
            int reputation = ScoreManager.instance.GetReputationScore();
            if (sanityScore <= -40)
            {
                if (reputation <= -40)
                {
                    //scared
                    lvl3_npc_dialogue_1.text = "Please don't kill us!";
                    lvl3_npc_dialogue_2.text = "My family is waiting for me once I get out!";
                    lvl3_npc_dialogue_3.text = "I don't want to die!";
                    lvl3_npc_dialogue_4.text = "Please let me finish my PhD before I die!";
                }
                else
                {
                    //mixed
                    lvl3_npc_dialogue_1.text = "I'm so scared, are we going to die next?";
                    lvl3_npc_dialogue_2.text = "Maybe he won't kill us like he did with the others?";
                    lvl3_npc_dialogue_3.text = "I have faith you'll do the right thing!";
                    lvl3_npc_dialogue_4.text = "Will you spare our lives?";
                }
            }
            else if (sanityScore <= -20)
            {
                if (reputation <= -20)
                {
                    //mixed
                    lvl3_npc_dialogue_1.text = "Just because he killed some prisoners doesn't mean he'll kill us.";
                    lvl3_npc_dialogue_2.text = "Don't anger him too much or we'll be next!";
                    lvl3_npc_dialogue_3.text = "If we leave him alone maybe we'll be spared.";
                    lvl3_npc_dialogue_4.text = "Nobody make any sudden movements and he wont come for us.";
                }
                else
                {
                    //neutral
                    lvl3_npc_dialogue_1.text = "He won't kill us like he did with the guard.";
                    lvl3_npc_dialogue_2.text = "I'm just looking forward to getting out of here.";
                    lvl3_npc_dialogue_3.text = "I wonder what's on the other side of this door?";
                    lvl3_npc_dialogue_4.text = "Does Arunpreet's have a middle name?";
                }
            }
            else if (sanityScore <= 0)
            {
                if (reputation < 0)
                {
                    //netural
                    lvl3_npc_dialogue_1.text = "Just because he killed some prisoners doesn't mean he'll kill us.";
                    lvl3_npc_dialogue_2.text = "Don't anger him too much or we'll be next!";
                    lvl3_npc_dialogue_3.text = "If we leave him alone maybe we'll be spared.";
                    lvl3_npc_dialogue_4.text = "Nobody make any sudden movements and he wont come for us.";
                }
                else 
                {
                    //positive
                    lvl3_npc_dialogue_1.text = "Plese save us too!";
                    lvl3_npc_dialogue_2.text = "You could let us out also!";
                    lvl3_npc_dialogue_3.text = "Do the right thing and break us free!";
                    lvl3_npc_dialogue_4.text = "Don't let us be locked in here!";
                    
                }
            }
            else
            {
                if (reputation <= 20)
                {
                    //positive
                    lvl3_npc_dialogue_1.text = "Help us!";
                    lvl3_npc_dialogue_2.text = "Break us free!";
                    lvl3_npc_dialogue_3.text = "If you break us out I'll buy you a beer at 3 Mile!";
                    lvl3_npc_dialogue_4.text = "You're so close to letting us out!";
                }
                else
                {
                    //very positive
                    lvl3_npc_dialogue_1.text = "You're our hero!";
                    lvl3_npc_dialogue_2.text = "Be the hero we don't deserve, but the hero we need!";
                    lvl3_npc_dialogue_3.text = "Whooo there's the man of the hour!";
                    lvl3_npc_dialogue_4.text = "Our savior is here!";
                }
            }
            doorOpened = true;
        }
        
    }
}
