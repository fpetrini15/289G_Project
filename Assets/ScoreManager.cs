using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int reputation = 0;
    private int sanityScore = 0;

    private int prisonersDestroyed = 0;

    public void Awake()
    {
        instance = this;
    }

    public void AdddPoints(int reputationPoints, int sanityPoints)
    {   
        reputation += reputationPoints;
        sanityScore += sanityPoints;
        Debug.Log("Reputation: " + reputation);
        Debug.Log("Sanity Score: " + sanityScore);
    }

    public int GetSanityScore()
    {
        return sanityScore;
    }

    public int GetReputationScore()
    {
        return reputation;
    }

    public void PrisonerDestroyed()
    {
        prisonersDestroyed += 1;
        Debug.Log(prisonersDestroyed);
    }

    public int GetPrisonerDestroyed()
    {
        return prisonersDestroyed;
    }

}
