using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public Animator anim;
    public int rpm;
    //public AudioSource shootSound;
    public UnityEvent onShoot;
    public GunAmmo gunAmmo;

    private float lastShot;
    private float interval;
    private bool isShooting;

    private void Start()
    {
        interval = 60f / rpm;
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Update()
    {
        //Debug.Log("Automatic Shooting");
        if (isShooting || Input.GetKey(KeyCode.Mouse0))
        {
            UpdateFiring();
            gunAmmo.SingleFireAmmoCounter();
        }

    }

    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    private void Shoot()
    {
        //shootSound.Play();
        anim.SetTrigger("Shoot");
        onShoot.Invoke();
    }

}
