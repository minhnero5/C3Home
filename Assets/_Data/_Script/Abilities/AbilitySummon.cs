using UnityEngine;

public class AbilitySummon : BaseAbilities
{
    [SerializeField] protected Spawner spawner ;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isRead) return;
        this.Summon();
    }

    protected virtual void Summon()
    {
        Transform spawnPoint = this.abilities.AbilityController.SpawnPoint.GetRandom();

        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, spawnPoint.position, spawnPoint.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }

}
