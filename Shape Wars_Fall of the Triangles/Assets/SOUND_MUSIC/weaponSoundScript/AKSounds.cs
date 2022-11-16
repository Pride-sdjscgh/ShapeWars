using UnityEngine.Audio;
using UnityEngine;
using System;

public class AKSounds : MonoBehaviour
{
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            PlaySFX();
        }
    }


    void PlaySFX()
    {
      FindObjectOfType<AudioManager>().Play("AK");
    }
    
}
