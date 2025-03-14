using UnityEngine;

public class HPBarSpawner : Spawner
{
    private static HPBarSpawner instance;

    public static HPBarSpawner Instance { get => instance; }

    public static string HPBar = "HPBar";

    protected override void Awake()
    {
        base.Awake();
        if (HPBarSpawner.instance != null) Debug.LogError("There is more HPBarSpawner than 1 instance");
        HPBarSpawner.instance = this;

    }
}
