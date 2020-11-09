using System;
using UnityEngine;

namespace UnityEngine
{
    public class TurretGun : MonoBehaviour
    {
        private const int ShootFrequency = 1;

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletStart;
        [SerializeField] private float _shootSpeed = 1.0f;
        private Transform _target;

        private float _lastShootTime = 0;

        public void Attack(Transform target)
        {
            _target = target;
        }

        public void Patrol()
        {
            if (_target is null)
            {
                return;
            }

            _target = null;
        }

        private void Update()
        {
            if (_target is null)
            {
                return;
            }
            
            transform.LookAt(_target);

            if (IsShootTime())
            {
                _lastShootTime = Time.time;
                GameObject bullet = Instantiate(_bullet, _bulletStart.position + new Vector3(0, 0, 1.0f), gameObject.transform.rotation);
                TurretBullet turretBullet = bullet.GetComponent<TurretBullet>();
                turretBullet.Attack(_target);
            }
        }

        private bool IsShootTime()
        {
            if (_lastShootTime == 0)
            {
                return true;
            }

            float deltaTime = Time.time - _lastShootTime;
            
            return deltaTime >= ShootFrequency * _shootSpeed;
        }
    }
}