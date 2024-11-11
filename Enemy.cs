using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract event Action<Enemy> HasDestroy;

    protected Transform _target;
    protected float _speed = 2f;

    public abstract void Init(Transform target);

    protected abstract void Move();
}