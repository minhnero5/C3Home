using UnityEngine;

public class RandomStringGenerator : ThanguMonoBehavior

{
    private const string chars = "abcdefghiklmnopqrstuvwxyz012345679";

    public static string Generate(int length)
    {
        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            randomString += chars[Random.Range(0,chars.Length)];
        }
        return randomString;
    }

}
