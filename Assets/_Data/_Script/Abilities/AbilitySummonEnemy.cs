using UnityEngine;

public class AbilitySummonEnemy :AbilitySummon 
{
   


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadEnemySpawner", gameObject);
    } 

    protected virtual void Summoning()
    {
        if (!this.isRead) return;
        this.Summon();
    }

    protected virtual void Summon()
    {
        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, transform.position, transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }

}
