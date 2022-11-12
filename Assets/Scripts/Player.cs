using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private float input;

    public GameObject bullet;

    private float moveForce = 20f;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
           

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ShootBullet();

    }

    private void MovePlayer()
    {
        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }

        input = Input.GetAxis("Horizontal");

        transform.position = new Vector3(transform.position.x + input * moveForce * Time.deltaTime, transform.position.y, 0);
    }

    private void ShootBullet()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        }


    }

    public void addScore()
    {
        score += 1;
    }

}
