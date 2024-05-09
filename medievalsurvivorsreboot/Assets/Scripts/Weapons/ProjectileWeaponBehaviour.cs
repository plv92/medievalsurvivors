using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all projectile weapons
/// </summary>
public class ProjectileWeaponsBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float DestroyAfterSeconds;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, DestroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }
}
