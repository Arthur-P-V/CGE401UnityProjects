/*
 Arthur Peterson-Veatch
 3d prototype
 This is a script to define the behavior of the gun object
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycast : MonoBehaviour
{

    public int damage = 10;
    public float range = 100f;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public float hitForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range)) {
            Debug.Log(hitInfo.transform.gameObject.name);

            Enemy target = hitInfo.transform.gameObject.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage(damage);

                if (hitInfo.rigidbody != null) { 
                    hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
                }
                
            }
        }
    }
}
