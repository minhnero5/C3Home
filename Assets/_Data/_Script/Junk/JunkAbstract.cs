using UnityEngine;

public abstract class JunkAbstract : ThanguMonoBehavior
{
    [SerializeField] private JunkController junkController;

    public JunkController JunkController { get => junkController;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
