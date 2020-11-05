using System;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2.0f;
    [SerializeField] private float _speed = 5.0f;

    private Transform _target;
    
    public void Attack(Transform target)
    {
        _target = target;
    }

    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        if (_target is null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 transformPosition = transform.position;
        if (_target is null)
        {
            return;
        }

        var targetPosition = _target.position;
        transform.position = Vector3.MoveTowards(transformPosition, targetPosition, _speed * Time.deltaTime);
    }
}