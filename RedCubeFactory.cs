using UnityEngine;

public class RedCubeFactory : MonoBehaviour, IEnemyFactory
{
    [SerializeField] private RedCube _prefab;

    private Transform _target;

    public Enemy CreateEnemy(Transform spawnPoint)
    {
        RedCube enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
        enemy.Init(_target);

        return enemy;
    }

    public void GetTarget(Transform target)
    {
        _target = target;
    }
}