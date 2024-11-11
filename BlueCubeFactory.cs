using UnityEngine;

public class BlueCubeFactory : MonoBehaviour, IEnemyFactory
{
    [SerializeField] private BlueCube _prefab;

    private Transform _target;

    public Enemy CreateEnemy(Transform spawnPoint)
    {
        BlueCube enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
        enemy.Init(_target);

        return enemy;
    }

    public void GetTarget(Transform target)
    {
        _target = target;
    }
}