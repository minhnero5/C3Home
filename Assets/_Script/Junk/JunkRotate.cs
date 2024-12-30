using UnityEngine;
using UnityEngine.PlayerLoop;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 euler = new Vector3(0, 0, 1);
        this.JunkController.Model.Rotate(euler * this.speed * Time.fixedDeltaTime);
    }
}
