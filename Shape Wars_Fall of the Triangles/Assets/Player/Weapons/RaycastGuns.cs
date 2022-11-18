using UnityEngine;
using UnityEngine.Audio;
using System;

public class RaycastGuns : MonoBehaviour
{
   public float damage = 10f;
   public float range = 100f;
   public float fireRate = 15f; //THIS AFFECT THE TimebtwShoot
   public float impactforce = 30f;

   public Camera fpsCam;
   public GameObject muzzleflash;
   public GameObject ImpactVFX;
   public GameObject Muzzle;
   public AudioSource Audio;


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
      Instantiate(muzzleflash, Muzzle);
       
      Audio.Play();

      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
      {

         Target target = hit.transform.GetComponent<Target>();
         if (target != null)
         {
            target.TakeDamage(damage);
         }

         if (hit.rigidbody != null)
         {
            hit.rigidbody.AddForce(-hit.normal * impactforce);
         }

         GameObject impactGO = Instantiate(ImpactVFX, hit.point, Quaternion.LookRotation(hit.normal));
         Destroy(impactGO, 1f);
      }
   }
}
