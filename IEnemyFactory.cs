using UnityEngine;

internal interface IEnemyFactory
{
    public Enemy CreateEnemy(Transform spawnPoint);

    public void GetTarget(Transform target);
}