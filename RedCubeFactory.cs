using UnityEngine;

public class RedCubeFactory : EnemyFactory
{
    [SerializeField] private RedCube _prefab;

    private void Awake()
    {
        Prefab = _prefab;
    }
}
