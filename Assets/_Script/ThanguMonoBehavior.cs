using UnityEngine;

public class ThanguMonoBehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected void Reset()
    {
        this.LoadComponents();
    }

    protected void Start()
    {
        
    }
    protected virtual void LoadComponents()
    {
        
    }
}
