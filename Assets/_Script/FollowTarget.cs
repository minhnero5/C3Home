using UnityEngine;
using UnityEngine.PlayerLoop;

public class FollowTarget : ThanguMonoBehavior
{
    [SerializeField] protected float speed = 7f;
    [SerializeField] protected Transform target;

    protected virtual void FixedUpdate()
    {
        this.FollowingTarget();
    }

    protected virtual void FollowingTarget()
    {
        if (this.target == null) Debug.LogError("No target",gameObject);
        transform.position = Vector3.Lerp(transform.position, this.target.position, speed * Time.fixedDeltaTime);
    }
}
