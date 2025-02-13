using UnityEngine;

public class SpawnerRandom : ThanguMonoBehavior
{
    [SerializeField] protected SpawnController junkCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<SpawnController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if(this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < randomDelay) return;
        this.randomTimer = 0;
            
        Transform ranPoints = this.junkCtrl.SpawnPoint.GetRandom();
        Vector3 pos = ranPoints.position;
        Quaternion rot = transform.rotation;

        Transform prefab=this.junkCtrl._spawner.RandomPrefab();
        Transform obj = this.junkCtrl._spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkCtrl._spawner.SpawnerCount;
        return currentJunk >= this.randomLimit;
    }
}
