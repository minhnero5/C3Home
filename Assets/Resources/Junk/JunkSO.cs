using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "ScripableObject/Junk")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public int hpMax = 2;
}
