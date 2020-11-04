using System;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStart;
    [SerializeField] private float _speed = 2.0f;

    private bool _isGrounded;
    private Vector3 _moveDirection;
    private Rigidbody _rb;
    private Vector3 _jump;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        MoveCheck();
        FireCheck();
        JumpCheck();
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(_jump, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        _isGrounded = true;
    }

    private void FireCheck()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _bulletStart.position, _bulletStart.rotation);
        }
    }

    private void MoveCheck()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");

        transform.position += _moveDirection * _speed * Time.deltaTime;
    }
}