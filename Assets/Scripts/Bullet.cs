using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        angle = Random.Range(-80f, 80f);
        rigidbody.velocity = Quaternion.Euler(0, 0, angle) * new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Character>().TakeDamage(1);
        }
    }
    public float angle;
    public float speed;
}