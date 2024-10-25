using Myd.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : Enemy
{
    public float coolDown;
    private float coolDownTimer;
    public float generateCoolDown;
    public float generateTimer;
    public GameObject bullet;
    public GameObject flyRobot;
    public GameObject spiderRobot;
    public Slider healthBar;
    public Transform generatePos;
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
        if (health <= 0)
        {
            SceneLoader.Instance.LoadScene("Epilogue");
            Destroy(gameObject);
        }
        base.Update();
        if (BossLevelSceneManager.Instance.bossAbleToAttack)
        {
            if (coolDownTimer < 0 && !isDead)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
                    Destroy(bulletObj, 10f);
                }
                coolDownTimer = coolDown;
            }
            if (generateTimer < 0 && !isDead)
            {
                generateTimer = generateCoolDown;
                Instantiate((Random.value > 0.5f) ? flyRobot : spiderRobot, generatePos.transform.position, Quaternion.identity);
            }
            coolDownTimer -= Time.deltaTime;
            generateTimer -= Time.deltaTime;
        }
    }
    public int maxHealth;
}
