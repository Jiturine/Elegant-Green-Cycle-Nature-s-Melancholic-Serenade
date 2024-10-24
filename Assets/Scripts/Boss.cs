using Myd.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : Enemy
{
    public float coolDown = 1f;
    private float coolDownTimer;
    public GameObject bullet;
    public Slider healthBar;
    public bool isDead;
    public int bulletCount = 3;
    new void Start()
    {
        base.Start();
        coolDownTimer = coolDown;
    }
    new void Update()
    {
        healthBar.value = (float)health / maxHealth;
        if (health < 0)
        {
            SceneManager.LoadScene("Epilogue");
        }
        base.Update();
        if (BossLevelSceneManager.Instance.bossAbleToAttack)
        {
            if (coolDownTimer < 0 && !isDead)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    GameObject bulletObj = Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
                    Destroy(bulletObj, 10f);
                }
                coolDownTimer = coolDown;
            }
            coolDownTimer -= Time.deltaTime;
        }
    }
    public int maxHealth;
}
