using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Character>().TakeDamage(2);
        }
    }
}