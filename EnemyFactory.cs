using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    protected Enemy Prefab;
    protected Transform Target;

    public virtual Enemy CreateEnemy(Transform spawnPoint)
    {
        Enemy enemy = Instantiate(Prefab, spawnPoint.position, Quaternion.identity);
        enemy.Init(Target);

        return enemy;
    }

    public virtual void SetTarget(Transform target)
    {
        Target = target;
    }
}