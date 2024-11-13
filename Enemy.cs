using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform Target;
    protected float Speed = 3f;

    public event Action<Enemy> HasDestroy;

    protected void Update()
    {
        Move();
    }

    public virtual void Init(Transform target)
    {
        Target = target;
    }

    protected virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Target>(out _))
        {
            HasDestroy?.Invoke(this);
        }
    }
}
