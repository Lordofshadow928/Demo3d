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

    private void Start()
    {
        playerHealth = Player.Instance.health;
    }
    public void OnAttack(int index)
    {
        Debug.Log("Player takes damage");
        playerHealth.TakeDamage(damage);
        if (index == 1)
        {
            Player.Instance.playerUi.ShowLeftScratch();
        }
        else
        {
            Player.Instance.playerUi.ShowRightScratch();
        }
    }
}
