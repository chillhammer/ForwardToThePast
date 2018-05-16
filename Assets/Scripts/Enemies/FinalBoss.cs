﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {
    public bool active = false;
    public bool chasing = true;
    public float battleStartRange = 10f;
    public float speed = 4f;
    public int maxHealth;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject slashObject;
    public float slashTime;

	// Use this for initialization
	void Start () {
        maxHealth = GetComponent<EnemyBasic>().health;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        StartCoroutine(SlashTimer());
	}

    IEnumerator SlashTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(slashTime);
            var created = Instantiate(slashObject);
            created.transform.position = transform.position;
        }
    }

	// Update is called once per frame
	void Update () {
		if (!active && (player.transform.position - transform.position).magnitude <= battleStartRange)
            active = true;
        if (active)
        {
            Vector3 direction = player.transform.position - transform.position;
            if (chasing)
                rb.AddForce(direction.normalized * speed);
        }
	}
}
