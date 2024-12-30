using UnityEngine;

public class JunkRandom : ThanguMonoBehavior
{
    [SerializeField] protected JunkSpawnerController junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    private void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoints = this.junkCtrl.SpawnPoint.GetRandom();
        Vector3 pos = ranPoints.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.junk1, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning),1f);
    }
}
