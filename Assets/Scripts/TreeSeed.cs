using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeed : MonoBehaviour
{
    public void Grow()
    {
        Instantiate(smallTreePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public GameObject smallTreePrefab;
}
