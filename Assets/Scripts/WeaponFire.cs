using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public float damage = 1f;
    public float range = 150f;
    public float force = 4f;
    public Camera playerCamera;
    public GameObject effect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            ShowEffect(hit);
            ApplyForce(hit);
            ApplyDamageOnEnemy(hit);
        }
    }

    private void ApplyDamageOnEnemy(RaycastHit hit)
    {
        Enemy enemy = hit.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageReceived(this.damage);
        }
    }

    private void ApplyForce(RaycastHit hit) 
    {
        Rigidbody componentCollisioned = hit.collider.GetComponent<Rigidbody>();
        if (componentCollisioned != null) 
        {
            AvoidConstraintOnPhysic(componentCollisioned);
            componentCollisioned.AddForce(hit.normal * force);
        }
    }

    private void AvoidConstraintOnPhysic(Rigidbody componentCollisioned)
    {
        componentCollisioned.constraints = RigidbodyConstraints.None;
    }

    private void ShowEffect(RaycastHit hit) 
    {
        GameObject _effect = Instantiate(this.effect, hit.point, Quaternion.identity);
        Destroy(_effect, 0.5f);
    }

    // show color on raycast
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * range);
    }

}
