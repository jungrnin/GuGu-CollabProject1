using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;           // 점프 힘
    public float rotationSpeed = 200f;     // 충돌 후 회전 속도
    public AudioClip flapSound;            // 점프 사운드 (선택)

    private Rigidbody2D rb;
    private bool isDead = false;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.gravityScale = 1f; // 중력 적용
    }

    void Update()
    {
        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;

            if (flapSound != null)
                audioSource.PlayOneShot(flapSound);
        }

        if (isDead)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            isDead = true;
            rb.velocity = new Vector2(2f, jumpForce); // 튕겨나감
            rb.gravityScale = 2f;                     // 더 빠르게 낙하
        }
    }

}
