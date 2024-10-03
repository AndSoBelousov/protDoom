using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speedBall = 10.0f;
    public int damage = 1;

    private void Update()
    {
        MovementBall();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }

    private void MovementBall()
    {
        transform.Translate(0, 0, speedBall * Time.deltaTime);
    }
}
