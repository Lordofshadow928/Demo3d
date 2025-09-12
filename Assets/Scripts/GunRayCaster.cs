using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRayCaster : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;

    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Debug.Log("Hit: " + hitInfo.collider.name);
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            DealDamage(hitInfo);
        }
    }

    private void DealDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log("Dealing " + damage + " damage to " + hitInfo.collider.name);
            health.TakeDamage(damage);
        }
    }
}
