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
        this.ResetValue();
    }

    protected virtual void OnEnable()
    {
        
    }
    protected virtual void Start()
    {
        
    }
    protected virtual void LoadComponents()
    {
        
    }

    protected virtual void ResetValue()
    {
        
    }
}
