using UnityEngine;

public class ParentFly : ThanguMonoBehavior
{
    [SerializeField] protected float moveSpeed = 9;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
