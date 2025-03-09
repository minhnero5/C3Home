using Unity.Mathematics;
using UnityEngine;

public class AbilityWarp : BaseAbilities
{
    [SerializeField] protected Spawner spawner;
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] private Vector4 warpDirection;
    [SerializeField] private float warpSpeed;
    [SerializeField] private float warpDistance;

    protected override void Update()
    {
        base.Update();
        this.CheckDirectionWarping();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
        
    }
    protected virtual void CheckDirectionWarping()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;

        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();
        
    }

    protected virtual void Warping()
    {
        if (this.isWarping) return;
        if (this.IsDirectionNotSet()) return;

        Debug.LogWarning("Warping");
        Debug.LogWarning(this.warpDirection);

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);

    }

    protected virtual bool IsDirectionNotSet()
    {
        return this.warpDirection.x == 0 && this.warpDirection.y == 0
            && this.warpDirection.z == 0 && this.warpDirection.w == 0;
    }

    protected virtual void WarpFinish()
    {
        this.MoveObj();
        Debug.LogWarning("<b>WarpFinish</b>");
        this.warpDirection.Set(0, 0, 0, 0);
        this.isWarping = false;
        this.Active();
    }

    protected virtual void MoveObj()
    {
        Transform obj = this.abilities.AbilityController.transform;
        Vector3 newPos = obj.position;
        Quaternion newRot = obj.rotation;
        if (this.warpDirection.x == 1)
        {
            newPos.x -= this.warpDistance;
            
        }
        if (this.warpDirection.y == 1)
        {
            newPos.x += this.warpDistance;

        }
        if (this.warpDirection.z == 1) newPos.y += this.warpDistance;
        if (this.warpDirection.w == 1) newPos.y -= this.warpDistance;

        Quaternion fxRot = this.GetObjQuaternion();
        Quaternion objRot = this.GetObjQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.impact1, obj.position, fxRot);
        fx.gameObject.SetActive(true);
        obj.position = newPos;
        obj.rotation = objRot;
    }



    protected virtual Quaternion GetObjQuaternion()
    {
        Vector3 vector = new Vector3();

        if (this.warpDirection.x == 1) vector.z = 180;
        if (this.warpDirection.y == 1) vector.z = 0;
        if (this.warpDirection.z == 1) vector.z = 90;
        if (this.warpDirection.w == 1) vector.z = -90;


        if (this.warpDirection.x == 1 && this.warpDirection.w == 1) vector.z = -135;
        if (this.warpDirection.y == 1 && this.warpDirection.w == 1) vector.z = -45;
        if (this.warpDirection.x == 1 && this.warpDirection.z == 1) vector.z = 135;
        if (this.warpDirection.y == 1 && this.warpDirection.z == 1) vector.z = 45;
        return Quaternion.Euler(vector);

    }
    protected virtual void WarpLeft()
    {

        Debug.Log("WarpLeft");
        this.warpDirection.x = 1;
    }

    protected virtual void WarpDown()
    {

        Debug.Log("WarpDown");
        this.warpDirection.w = 1;
    }

    protected virtual void WarpRight()
    {

        Debug.Log("WarpRight");
        this.warpDirection.y = 1;
    }

    protected virtual void WarpUp()
    {
        Debug.Log("WarpUp");
        this.warpDirection.z = 1;
    }
}
