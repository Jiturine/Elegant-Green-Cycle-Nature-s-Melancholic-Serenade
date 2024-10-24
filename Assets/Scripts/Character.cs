using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Myd.Platform;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public static Character Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        player = Game.Instance.player;
        swordVFXOffestX = 1.5f;
        attackSize = new Vector2(1.5f, 1.5f);
        maxHealth = 10;
        Health = 10;
        swordVFX = Resources.Load<GameObject>("SwordVFX");
        GameObject sfxObject = new GameObject("moveSFX");
        AudioManager.Instance.playerMoveSFX = sfxObject.AddComponent<AudioSource>();
        AudioManager.Instance.playerMoveSFX.clip = Resources.Load<AudioClip>("AudioClip/PlayerMovement");
        AudioManager.Instance.playerMoveSFX.loop = true;
        AudioManager.Instance.playerMoveSFX.Play();
        AudioManager.Instance.playerMoveSFX.Pause();
    }

    void Update()
    {
        CheckBoundary();
        AnimateUpdate();
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
        if (Input.GetKeyDown(abilityKey))
        {
            UseAbility();
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
    public void Attack()
    {
        GameObject vfxObject = Instantiate(swordVFX, new Vector3(transform.position.x + swordVFXOffestX * (int)player.playerController.Facing, transform.position.y), Quaternion.identity);
        vfxObject.transform.localScale = new Vector3((int)player.playerController.Facing * vfxObject.transform.localScale.x, vfxObject.transform.localScale.y, vfxObject.transform.localScale.z);
        Destroy(vfxObject, 0.3f);
    }
    // -------------------------debug-------------------------------
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireCube(Game.Instance.level.Bounds.center, Game.Instance.level.Bounds.size);
    // }
    public void UseAbility()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        var hitColliders = Physics2D.OverlapBoxAll(pos, abilitySize, 0);
        if (hitColliders != null)
        {
            foreach (var collider in hitColliders)
            {
                if (collider.CompareTag("Interactable"))
                {
                    if (collider.TryGetComponent<TreeSeed>(out var treeSeed))
                    {
                        treeSeed.Grow();
                    }
                    if (collider.TryGetComponent<SmallTree>(out var smallTree))
                    {
                        smallTree.Grow();
                    }
                }
            }
        }
    }
    public void CheckBoundary()
    {
        var bounds = Game.Instance.level.Bounds;
        if (transform.position.x < bounds.center.x - bounds.size.x / 2f ||
        transform.position.x > bounds.center.x + bounds.size.x / 2f ||
        transform.position.y < bounds.center.y - bounds.size.y / 2f ||
        transform.position.y > bounds.center.y + bounds.size.y / 2f)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        player.playerRenderer.spriteRenderer.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
        Health -= damage;
        hurted = true;
        Game.Instance.CameraShake(player.GetCameraPosition(), 0.2f);
        player.playerController.Speed *= -0.5f;
    }
    public void Die()
    {
        health = 10;
        healthBar.value = 1f;
        player.playerController.Position = Game.Instance.level.StartPosition;
    }
    public void AnimateUpdate()
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
    }
    public bool hurted;
    public Vector2 attackAreaPos;
    public Vector2 attackSize;
    public Player player;
    public Animator animator;
    public GameObject swordVFX;
    public float swordVFXOffestX = 1.0f;
    public KeyCode attackKey = KeyCode.J;
    public KeyCode abilityKey = KeyCode.L;
    public int health;
    public int maxHealth;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            healthBar.value = (float)health / maxHealth;
            if (health < 0)
            {
                Die();
            }
        }
    }
    public Vector2 abilitySize;
    public Slider healthBar;
}
