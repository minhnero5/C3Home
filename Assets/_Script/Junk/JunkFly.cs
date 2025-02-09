using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -15;
    [SerializeField] protected float maxCamPos = 15;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 1;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = this.GetCamPosition();
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
        Debug.DrawLine(objPos, objPos + diff * 7, Color.magenta, Mathf.Infinity);
    }

    protected virtual Vector3 GetCamPosition()
    {
        if (GameController.Instance == null) return Vector3.zero;
        Vector3 camPos = GameController.Instance.MainCamera.transform.position;
        return camPos;
    }
}
