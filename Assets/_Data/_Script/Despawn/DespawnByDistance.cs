using UnityEngine;

public class DespawnByDistance : DeSpawn
{
    [SerializeField] protected float disLimit = 70;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Transform mainCamTran;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamTran != null) return;
        this.mainCamTran = Transform.FindAnyObjectByType<Camera>().transform;
        Debug.Log(transform.parent.name + ":Load Camera");
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.mainCamTran.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
