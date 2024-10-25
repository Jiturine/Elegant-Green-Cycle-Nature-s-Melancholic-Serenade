using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRobot : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        Vector3 moveDirection = (Character.Instance.transform.position - transform.position).normalized;
        float facing = (moveDirection.x > 0) ? 1 : -1;
        transform.localScale = new Vector3(facing, 1, 1);
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
    }
    public float moveDirection;
    public float moveSpeed;
    public Animator animator;
}
