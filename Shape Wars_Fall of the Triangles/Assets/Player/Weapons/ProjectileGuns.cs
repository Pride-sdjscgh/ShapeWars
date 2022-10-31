using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ProjectileGuns : MonoBehaviour
 {
    public float fireRate = 20f; //THIS AFFECT THE TimebtwShoot
    public float bulletSpeed = 100f; 
    public ParticleSystem muzzleflash;
   
    public Rigidbody Bullet;
    public Transform Muzzle;
    private float nextTimeToFire = 0f;

    // Update is called once per frame
      void Update()
      {
         if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
         {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
         }
      }


    void Shoot()
     {
        muzzleflash.Play();

        Rigidbody projectileInstance;
        projectileInstance = Instantiate(Bullet, Muzzle.position, Muzzle.rotation) as Rigidbody;
        projectileInstance.AddForce(-Muzzle.forward * bulletSpeed);
     }
     
}
