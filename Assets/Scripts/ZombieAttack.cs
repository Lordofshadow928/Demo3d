using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public Health playerHealth;

    public void StartAttack()
    {
        Debug.Log("Attack started");
        anim.SetBool("isAttack", true);
    }

    public void StopAttack()
    {
        anim.SetBool("isAttack", false);
    }

    public void OnAttack()
    {
        Debug.Log("Player takes damage");
        playerHealth.TakeDamage(damage);
    }
}
