using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    public Animator anim;
    public int rpm;
    public AudioSource shootSound;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public UnityEvent onShoot; 

    private float lastShot;
    private float interval;

    private void Start()
    {
        interval = 60f / rpm;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            UpdateFiring();
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
        shootSound.Play();
        anim.SetTrigger("AutoShoot");
        PerformRayCasting();
        onShoot.Invoke();
    }

    private void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
        }
    }
}
