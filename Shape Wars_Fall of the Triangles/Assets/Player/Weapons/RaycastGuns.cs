using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;

public class RaycastGuns : MonoBehaviour
{
   public float damage = 10f;
   public float range = 100f;
   public float fireRate = 15f; //THIS AFFECT THE TimebtwShoot
   public float impactforce = 30f;

   //Ammo stuff
   public int maxAmmo = 20;
   private int currentAmmo;
   public float reloadTime = 5;
   private bool isReloding = false;

   public Camera fpsCam;
   public GameObject muzzleflash;
   public GameObject ImpactVFX;
   public Transform Muzzle;
   public AudioSource Audio;

   public Animator animator;

   void start()
   {
       currentAmmo = maxAmmo;
       animator.SetBool("Reloading", false);
   }

   void OnEnable ()
   {
     isReloding = false;
     animator.SetBool("Reloading", true);

   }


   private float nextTimeToFire = 0f;

   // Update is called once per frame
   void Update()
   {
      if (isReloding)
          return;

      if (currentAmmo <= 0)
      {
        StartCoroutine(Reload());
          return;
      }

      if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
      {
         nextTimeToFire = Time.time + 1f / fireRate;
         Shoot();
      }
   }

   IEnumerator Reload ()
   {
      isReloding = true;
      Debug.Log ("Reloading....");

      animator.SetBool("Reloading", true);

      yield return new WaitForSeconds (reloadTime - .25f);
      animator.SetBool("Reloading", false);
       yield return new WaitForSeconds (.25f);

      currentAmmo = maxAmmo;
      isReloding = false;
   }

   void Shoot()
   {
      Instantiate(muzzleflash, Muzzle);
       
      Audio.Play();

      currentAmmo--;

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
