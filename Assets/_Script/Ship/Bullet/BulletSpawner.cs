using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;

    public static BulletSpawner Instance { get => instance;}

    public static string bullet1 = "Bullet";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more BulletSpawner than 1 instance");
        BulletSpawner.instance = this;
        
    }
}
