using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Explosive
{
    [SerializeField]
    private float _movementSpeed = 1f;

    public Damageable HitTarget { get; set; }

    public override void TakeDamage()
    {
        IsAlive = false;

        Explode();
    }

    private void Start()
    {
        IsAlive = true;
    }

    private void Update()
    {
        MovementUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == HitTarget.gameObject)
        {
            HitTarget.TakeDamage();
            Explode();
        }
    }

    private void MovementUpdate()
    {
        if (HitTarget && HitTarget.IsAlive)
        {
            transform.position += transform.forward * _movementSpeed * Time.deltaTime;
            transform.LookAt(HitTarget.transform);
        }
    }
}
