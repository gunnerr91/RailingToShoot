using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>().isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        var gbExFx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        gbExFx.transform.parent = parent;
        Destroy(gameObject);
    }
}
