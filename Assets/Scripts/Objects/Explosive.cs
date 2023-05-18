using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Damageable
{
    [SerializeField]
    private ParticleSystem _explosion;

    public void Explode()
    {
        if (_explosion)
            Instantiate(_explosion, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);

        Destroy(gameObject);
    }
}
