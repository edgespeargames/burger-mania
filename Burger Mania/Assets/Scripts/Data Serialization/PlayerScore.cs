using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface 

// Taken from the Unity Learn example
// Implements IComparable interface
// Structs are best suited for small data structures that contain primarily data that is not intended to be modified after the struct is created.
[System.Serializable]
public struct PlayerScore : IComparable<PlayerScore>
{
    public string name;
    public int finalScore;

    public int CompareTo(PlayerScore other)
    {
        if (other.Equals(null))
        {
            return 1;
        }

        //Return the difference in score
        return finalScore - other.finalScore;
    }

}

