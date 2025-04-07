using UnityEngine;

public class Pressable : ThanguMonoBehavior
{
    public virtual void Pressed()
    {
        Debug.Log("Pressed: " + transform.parent.parent.name);
    }
}
