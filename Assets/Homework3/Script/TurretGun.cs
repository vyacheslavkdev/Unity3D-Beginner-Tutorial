using System;
using UnityEngine;

namespace UnityEngine
{
    public class TurretGun : MonoBehaviour
    {
        private const int ShootFrequency = 1;

        [SerializeField] private GameObject _bullet;
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
                Vector3 parentPosition = gameObject.transform.position;
                Vector3 position = new Vector3(parentPosition.x + 1, parentPosition.y + 1.5f, parentPosition.z + 1);
                GameObject bullet = Instantiate(_bullet, position, gameObject.transform.rotation);
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
            Debug.Log(deltaTime);
            
            return deltaTime >= ShootFrequency * _shootSpeed;
        }
    }
}