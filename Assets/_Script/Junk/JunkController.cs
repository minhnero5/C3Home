using UnityEngine;

public class JunkController : ThanguMonoBehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected SpawnPoint spawnPoint;
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    public SpawnPoint SpawnPoint { get => spawnPoint; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }
    
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindAnyObjectByType<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
