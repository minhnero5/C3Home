using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more JunkSpawner than 1 instance");
        EnemySpawner.instance = this;

    }
}
