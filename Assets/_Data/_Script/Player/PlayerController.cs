using UnityEngine;

public class PlayerController : ThanguMonoBehavior
{
    private static PlayerController instance;

    public static PlayerController Instance => instance;

    [SerializeField] protected ShipController currentShip;

    public ShipController CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;

    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerController.instance != null) Debug.LogError("Only 1 PlayerController allow");
        PlayerController.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": Load PlayerPick", gameObject);
    }
}
