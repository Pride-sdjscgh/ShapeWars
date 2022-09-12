using UnityEngine;

public class ProjectileGuns : MonoBehaviour
{
    public float fireRate = 15f; //THIS AFFECT THE TimebtwShoot
    
    public ParticleSystem muzzleflash;
   
    public GameObject Bullet;
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

       Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
    }
  
}
