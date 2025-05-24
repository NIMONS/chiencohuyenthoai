using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : CCHTMonoBehaviour
{
    [SerializeField] protected int health = 10;

    protected void takeDamage(int damage)
    {
        this.health -= damage;
        if (this.health < 0)
        {
            this.PlayerDie();
        }
    }

    protected void PlayerDie()
    {
        Debug.Log("You Die");
    }
}
