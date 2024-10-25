using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRobot : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        moveDirection = (Random.value > 0.5f) ? 1f : -1f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.localScale = new Vector3(moveDirection, 1, 1);
        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 3f, layerMask);
        RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, Vector2.right * moveDirection, 3f, layerMask);
        if (groundCheck.collider == null || wallCheck.collider != null)
        {
            moveDirection *= -1; // 反向
        }
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime * Vector2.right);
    }
    public float moveDirection;
    public float moveSpeed;
    public Animator animator;
}
