using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    static int i = 0;
    static int val = 0;
    public static int Odds(int Min, int Max, int OddsMin)
    {
        if (i < OddsMin) { val = Min; i++; } else i++; // Min show up OddsMin times before every GO has the same probability of showing up 
        if (i >= OddsMin) { val = Random.Range(Min, Max + 1); } // Add + 1 so max is included // same probability
        if (val == Max) { i = 0; } // if max reset and start again
        return val;
    }
}
