using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponsControler
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position;
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.moveDir); // Reference and set direction
    }
}
