using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    private const int leftMouseButton = 0;
    public GameObject bulletPrefab;
    public Transform firingPos;
    public float bulletSpeed;
    public AudioSource shootingSound;
    public Animator anim;

    void Update()
    {
        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            ShootBullet();
        }
	}

    private void ShootBullet() => anim.SetTrigger("Shoot");

    public void PlayFireSound() => shootingSound.Play();

    public void AddProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firingPos.forward * bulletSpeed;
	}
}
