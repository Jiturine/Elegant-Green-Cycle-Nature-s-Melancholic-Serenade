using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTree : MonoBehaviour
{
    public void Grow()
    {
        Instantiate(largeTreePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public GameObject largeTreePrefab;
}
