using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;

    public static MotherShipSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more MotherShipSpawner than 1 instance");
        MotherShipSpawner.instance = this;

    }
}
