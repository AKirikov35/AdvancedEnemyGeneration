using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] Target[] _targets;
    [SerializeField] Transform _redCubeSpawnPoint;
    [SerializeField] Transform _blueCubeSpawnPoint;

    private ObjectPool<RedCube> _redCubePool;
    private ObjectPool<BlueCube> _blueCubePool;

    private RedCubeFactory _redCubeFactory;
    private BlueCubeFactory _blueCubeFactory;
    private WaitForSeconds _waitForSeconds;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 20;

    private float _delay = 2.0f;

    private bool _isActive;

    private void Awake()
    {
        if (_targets.Length == 0)
            return;

        if (_redCubeSpawnPoint == null || _blueCubeSpawnPoint == null)
            return;

        _redCubeFactory = GetComponent<RedCubeFactory>();
        _blueCubeFactory = GetComponent<BlueCubeFactory>();

        _redCubePool = new ObjectPool<RedCube>(
            createFunc: () => (RedCube)_redCubeFactory.CreateEnemy(_redCubeSpawnPoint),
            actionOnGet: (enemy) => GetAction(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy),
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);

        _blueCubePool = new ObjectPool<BlueCube>(
            createFunc: () => (BlueCube)_blueCubeFactory.CreateEnemy(_blueCubeSpawnPoint),
            actionOnGet: (enemy) => GetAction(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy),
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);

        _isActive = true;
        StartCoroutine(SpawnCoroutine());
    }

    private void GetAction(Enemy enemy)
    {
        Transform target = _targets[Random.Range(0, _targets.Length)].transform;

        if (enemy is BlueCube blueCube)
        {
            _blueCubeFactory.GetTarget(target);
            blueCube.Init(target);
        }
        else if (enemy is RedCube redCube)
        {
            _redCubeFactory.GetTarget(target);
            redCube.Init(target);
        }

        enemy.gameObject.SetActive(true);
        enemy.HasDestroy += ReleaseAction;
    }

    private void ReleaseAction(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.HasDestroy -= ReleaseAction;
    }

    private void Deactivate()
    {
        _isActive = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnCoroutine()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        while (_isActive)
        {
            yield return _waitForSeconds;

            _blueCubePool.Get();
            _redCubePool.Get();
        }
    }
}