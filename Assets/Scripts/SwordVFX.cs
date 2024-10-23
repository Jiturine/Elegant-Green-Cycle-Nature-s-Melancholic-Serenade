using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordVFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hurtedEnemy != null) return;
        if (other.CompareTag("Enemy"))
        {
            hurtedEnemy = other.GetComponent<Enemy>();
            hurtedEnemy.TakeDamage(damage);
        }
    }
    public Enemy hurtedEnemy;
    public int damage;
}
