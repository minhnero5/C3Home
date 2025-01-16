using UnityEngine;

public class PlayerAbstract : ThanguMonoBehavior
{
    [SerializeField] protected PlayerController controller;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.controller != null) return;
        this.controller = transform.GetComponentInParent<PlayerController>();
    }
}
