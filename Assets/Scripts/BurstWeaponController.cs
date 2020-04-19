using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;

    public float fireRate1;
    public float fireRate2;
    public float fireRate3;
    public float delay1;
    public float delay2;
    public float delay3;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire1", delay1, fireRate1);

        InvokeRepeating("Fire2", delay2, fireRate2);

        InvokeRepeating("Fire3", delay3, fireRate3);
    }

    void Fire1()
    {
        Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        audioSource.Play();
    }

    void Fire2()
    {
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        audioSource.Play();
    }

    void Fire3()
    {
        Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
        audioSource.Play();
    }
}