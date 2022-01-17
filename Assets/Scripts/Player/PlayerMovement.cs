using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _speed;
    
    private Animator _animator;
    private Rigidbody _rigidbody;

    public event UnityAction Landed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, 0, _joystick.Vertical * _speed);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (Math.Abs(_joystick.Horizontal) >= _joystick.DeadZone || Math.Abs(_joystick.Vertical) >= _joystick.DeadZone)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }

        if(_rigidbody.velocity.magnitude >= 0.2f)
        {
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    public void EnableMovement()
    {
        this.enabled = true;
        Landed?.Invoke();
    }

    public void DisableMovement()
    {
        this.enabled = false;
        _rigidbody.velocity = Vector3.zero;
        _animator.SetFloat("Speed", 0);
    }
}
