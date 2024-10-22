using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Myd.Platform;
using UnityEditor.U2D.Aseprite;
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
        //
        GameObject sfxObject = new GameObject("SoundEffect");
        AudioManager.Instance.playerMoveSFX = sfxObject.AddComponent<AudioSource>();
        AudioManager.Instance.playerMoveSFX.clip = Resources.Load<AudioClip>("AudioClip/PlayerMovement");
        AudioManager.Instance.playerMoveSFX.loop = true;
        AudioManager.Instance.playerMoveSFX.Play();
        AudioManager.Instance.playerMoveSFX.Pause();
    }
    void Update()
    {
        if (Input.GetKey(GameInput.Jump.key))
        {
            animator.SetBool("Jump", true);
        }
        if (player.playerController.OnGround)
        {
            animator.SetBool("Jump", false);
        }
        if (player.playerController.stateMachine.State == (int)EActionState.Climb || player.playerController.WallSlideDir != 0)
        {
            animator.SetBool("Climb", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Climb", false);
        }
        if (player.playerController.OnGround && player.playerController.MoveX != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (animator.GetBool("Climb") == true)
        {
            if (player.playerController.MoveY == 0)
            {
                animator.speed = 0;
            }
            else
            {
                animator.speed = 1.0f;
            }
        }
        else
        {
            animator.speed = 1.0f;
        }
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
        if (player.playerController.MoveX != 0 && player.playerController.OnGround)
        {
            AudioManager.Instance.PlayMoveSFX();
        }
        else
        {
            AudioManager.Instance.StopMoveSFX();
        }
    }
    void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(attackAreaPos, attackSize, 0f);
    }
    // -------------------------debug-------------------------------
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
        Game.Instance.CameraShake(player.GetCameraPosition(), 0.1f);
    }
    public bool hurted;
    public float attackOffsetX;
    public float attackOffsetY;
    public Vector2 attackAreaPos;
    public Vector2 attackSize;
    public Player player;
    public Animator animator;
    public KeyCode attackKey = KeyCode.J;
    public int health;
    public int maxHealth;
}
