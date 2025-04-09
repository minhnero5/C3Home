using System;
using UnityEngine;
using UnityEngine.DedicatedServer;

public enum AbilitiesCode
{
    NoAbility = 0,

    Missle = 1,
    Laze = 2,
}

public class AbilitiesParser
{
    public static AbilitiesCode FromString(string itemName)
    {
        try
        {
            return (AbilitiesCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilitiesCode.NoAbility;
        }
    }
}
