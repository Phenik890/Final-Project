using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public float player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Pickup"))
        {
            return;
        }

        if (other.gameObject.CompareTag("Player Controller"))
        {
            DestroyPickup();
        }
    }

    void DestroyPickup()
    {
        Destroy(gameObject);
        SpawnShield();
    }

    void SpawnShield()
    {
        Transform charTransform = GameObject.FindGameObjectWithTag("Player Controller").transform;

        GameObject newShield = Instantiate(shield, charTransform.transform.position, charTransform.transform.rotation);

        newShield.transform.SetParent(charTransform.transform);
    }
}
