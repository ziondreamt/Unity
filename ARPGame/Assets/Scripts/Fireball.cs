﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    void Start()
    {
        Range = 20f;
        Damage = 5;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);    // 50f value here is a speed that can be replaced with a variable later.
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinguish();
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

}
