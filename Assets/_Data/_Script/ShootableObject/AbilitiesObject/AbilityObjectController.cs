using UnityEngine;

public abstract class AbilityObjectController : ShootableObjectController
{
    [SerializeField] private SpawnPoint spawnPoint;

    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = GetComponentInChildren<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
