using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScores : MonoBehaviour
{
    private int reputation;
    public TMP_Text reputationElement;

    private int sanityScore;
    public TMP_Text sanityScoreElement;

    public TMP_Text anarchistOrPacifist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reputation = ScoreManager.instance.GetReputationScore();
        reputationElement.text = "Reputation: " + reputation.ToString();
        sanityScore = ScoreManager.instance.GetSanityScore();
        sanityScoreElement.text = "Sanity Score: " + sanityScore.ToString();

        if (sanityScore <= -40)
            {
                if (reputation <= -40)
                {
                    //scared
                    anarchistOrPacifist.text = "Heavy Anarchist";
                }
                else
                {
                    //mixed
                    anarchistOrPacifist.text = "Moderate Anarchist";
                }
            }
            else if (sanityScore <= -20)
            {
                if (reputation <= 5)
                {
                    //mixed
                    anarchistOrPacifist.text = "Moderate Anarchist";
                }
                else
                {
                    //neutral
                    anarchistOrPacifist.text = "Neutral";
                }
            }
            else if (sanityScore <= 0)
            {
                if (reputation < 0)
                {
                    //netural
                    anarchistOrPacifist.text = "Neutral";
                }
                else 
                {
                    //positive
                    anarchistOrPacifist.text = "Moderate Pacifist";
                    
                }
            }
            else
            {
                if (reputation <= 20)
                {
                    //positive
                    anarchistOrPacifist.text = "Moderate Pacifist";
                }
                else
                {
                    //very positive
                    anarchistOrPacifist.text = "Heavy Pacifist";
                }
            }
        
    }
}
