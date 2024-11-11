using System;
using UnityEngine;

public class BlueCube : Enemy
{
    public override event Action<Enemy> HasDestroy;

    private void Update()
    {
        Move();
    }

    public override void Init(Transform target)
    {
        _target = target;
    }

    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Target>(out _))
        {
            HasDestroy?.Invoke(this);
        }
    }
}