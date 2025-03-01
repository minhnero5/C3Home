using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.03f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (_rb != null) return;
        this._rb = GetComponent<Rigidbody>();
        this._rb.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.BulletController.Shooter) return;

        this.BulletController.DamageSender.Send(other.transform);
        //this.CreateFXImpact();
    }

    //protected virtual void CreateFXImpact()
    //{
    //    string fxName = this.GetImpactFX();

    //    Vector3 hitPos = transform.position;
    //    quaternion hitRos = transform.rotation;
    //    Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRos);
    //    fxImpact.gameObject.SetActive(true);
    //}

    //protected virtual string GetImpactFX()
    //{
    //    return FXSpawner.impact1;
    //}
}
