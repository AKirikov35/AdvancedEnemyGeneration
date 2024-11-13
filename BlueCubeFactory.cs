using UnityEngine;

public class BlueCubeFactory : EnemyFactory
{
    [SerializeField] private BlueCube _prefab;

    private void Awake()
    {
        Prefab = _prefab;
    }
}
