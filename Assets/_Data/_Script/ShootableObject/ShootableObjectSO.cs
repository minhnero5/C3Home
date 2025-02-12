using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObjectSO", menuName = "SO/ShootableObjectSO")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "Shootable";
    public ObjectType objType;
    public int hpMax = 2;
    public List<DropRate> dropList;
}
