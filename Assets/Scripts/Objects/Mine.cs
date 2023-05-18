using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Explosive
{
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<Damageable>();

        if (damageable != null)
            damageable.TakeDamage();

        Explode();
    }
}
