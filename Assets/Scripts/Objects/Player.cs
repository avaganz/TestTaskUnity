using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    [SerializeField]
    private float _movementSpeed = 1f;

    [SerializeField]
    private Rigidbody _rigidbody;

    public bool IsOnGround => Physics.Raycast(transform.position + new Vector3(0f, 0.75f, 0f), -transform.up, 1f);

    public Action Died { get; set; }

    public override void TakeDamage()
    {
        Debug.Log("Player died");

        IsAlive = false;

        Fall();

        if (Died != null)
            Died.Invoke();
    }

    private void Start()
    {
        IsAlive = true;
    }

    private void Update()
    {
        if (IsAlive)
            MovementUpdate();
    }

    private void MovementUpdate()
    {
        if (IsOnGround)
            _rigidbody.velocity = transform.forward * InputController.Instance.Delta.y * _movementSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0f, InputController.Instance.Delta.x, 0f) * Time.deltaTime, Space.World);
    }

    private void Fall()
    {
        _rigidbody.angularDrag = 0f;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.velocity = transform.right * 1f;
    }
}
