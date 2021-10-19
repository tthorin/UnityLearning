using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shot;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime && !GetComponent<PlayerMovement>().IsCrouching)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Shoot()
    {
        Instantiate(shot, firePoint.position, firePoint.rotation);
    }
}
