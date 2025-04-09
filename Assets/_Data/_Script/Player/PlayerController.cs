using UnityEngine;

public class PlayerController : ThanguMonoBehavior
{
    private static PlayerController instance;

    public static PlayerController Instance => instance;

    [SerializeField] protected ShipController currentShip;

    public ShipController CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;

    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;

    public PlayerAbility PlayerAbility => playerAbility;


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
        this.LoadPlayerAbility();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": Load PlayerPick", gameObject);
    }

    protected virtual void LoadPlayerAbility()
    {
        if (this.playerAbility != null) return;
        this.playerAbility = transform.GetComponentInChildren<PlayerAbility>();
        Debug.Log(transform.name + ": Load PlayerAbility", gameObject);
    }
}
