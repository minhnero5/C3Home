using UnityEngine;

public abstract class ObjectShooting : ThanguMonoBehavior
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    //[SerializeField] protected Transform bulletPrefab;

    private void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet1,spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletController bulletController = newBullet.GetComponent<BulletController>();
        bulletController.SetShooter(transform.parent);
    }

    protected abstract bool IsShooting();

}
