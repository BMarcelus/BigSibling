using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Transform sprite;
    private Rigidbody2D rb;
    private Animator animator;
    private static Vector3 forwardsScale = new Vector3(1,1,1);
    private static Vector3 flipScale = new Vector3(-1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 targetVelocity = new Vector3(
            horizontal*speed,
            vertical*speed,
            0
        );
        rb.velocity = targetVelocity;
        animator.SetBool("Moving", targetVelocity!=Vector3.zero);
        animator.SetFloat("YVelocity", targetVelocity.y);
        if(horizontal<0)sprite.localScale = forwardsScale;
        if(horizontal>0)sprite.localScale = flipScale;
    }
}
