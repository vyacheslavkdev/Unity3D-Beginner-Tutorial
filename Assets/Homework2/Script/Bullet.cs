using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2.0f;
    [SerializeField] private float _speed = 2.0f;
    
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}