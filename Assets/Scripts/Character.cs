using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        player = Game.Instance.player;
        attackOffsetX = 0.86f;
        attackOffsetY = -0.12f;
        attackSize = new Vector2(1.5f, 1.5f);
        health = 10;
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
        if (hurted)
        {
            float g = Mathf.MoveTowards(player.playerRenderer.spriteRenderer.color.g, 1.0f, 1.75f * Time.deltaTime);
            float b = Mathf.MoveTowards(player.playerRenderer.spriteRenderer.color.b, 1.0f, 1.75f * Time.deltaTime);
            player.playerRenderer.spriteRenderer.color = new Color(1.0f, g, b, 1.0f);
            if (g == 1.0f && b == 1.0f)
            {
                hurted = false;
            }
        }
    }
    void Attack()
    {

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(attackAreaPos, attackSize, 0f);
    }
    //debug
    // private void OnDrawGizmosSelected()
    // {
    //     attackAreaPos = transform.position;
    //     attackAreaPos.x += attackOffsetX * (int)player.playerController.Facing;
    //     attackAreaPos.y += attackOffsetY;
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireCube(attackAreaPos, attackSize);
    // }
    public void TakeDamage(int damage)
    {
        player.playerRenderer.spriteRenderer.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        health -= damage;
        hurted = true;
    }
    public bool hurted;
    public float attackOffsetX;
    public float attackOffsetY;
    public Vector2 attackAreaPos;
    public Vector2 attackSize;
    public Player player;
    public KeyCode attackKey = KeyCode.J;
    public int health;
    public int maxHealth;
}
