using Mono.Cecil;
using UnityEngine;

public class SpawnController : ThanguMonoBehavior
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected SpawnPoint spawnPoint;
    public Spawner _spawner => spawner;
    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }
    
    protected virtual void LoadJunkSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindAnyObjectByType<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
