using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 45.0f;
    private TurretGun _turretGun;

    private GameObject _target = null;

    void Start()
    {
        _turretGun = gameObject.GetComponentInChildren<TurretGun>();
    }

    void Update()
    {
        if (_target is null)
        {
            Patrol();
        }
        else
        {
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _target = other.gameObject;
    }
    
    private void OnTriggerExit(Collider other)
    {
        _target = null;
    }

    private void Attack()
    {
        _turretGun.Attack(_target.transform);
    }

    private void Patrol()
    {
        _turretGun.Patrol();
        _turretGun.transform.Rotate(0, _patrolSpeed * Time.deltaTime, 0);
    }
}
