using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;

    public static JunkSpawner Instance { get => instance; }

    public static string bullet1 = "Junk";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more JunkSpawner than 1 instance");
        JunkSpawner.instance = this;

    }
}
