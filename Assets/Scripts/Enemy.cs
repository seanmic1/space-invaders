using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    private float moveForce = 3f;

    private int health = 3;

    private SpriteRenderer sr;

    public UnityEvent death;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (health == 3)
        {
            sr.color = new Color(1f,0f,0f);
        }
        else if (health == 2)
        {
            sr.color = new Color(1f, 0.5f, 0f);
        }
        else if (health == 1)
        {
            sr.color = new Color(1f, 1f, 0f);
        }
    }

    private void MoveEnemy()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - moveForce * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            health -= 1;

            if (health == 0)
            {

                death.Invoke();

                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
