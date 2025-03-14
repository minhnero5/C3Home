using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more EnemySpawner than 1 instance");
        EnemySpawner.instance = this;

    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBarToObject(newEnemy);
        return newEnemy;
    }

    protected virtual void AddHPBarToObject(Transform newEnemy)
    {
        ShootableObjectController newEnemyController = newEnemy.GetComponent<ShootableObjectController>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.SetObjectController(newEnemyController);
        hpBar.SetFollowTarget(newEnemy);
        newHPBar.gameObject.SetActive(true);
    }
}
