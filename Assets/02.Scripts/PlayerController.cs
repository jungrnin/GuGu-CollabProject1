using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;           // ���� ��
    public float rotationSpeed = 200f;     // �浹 �� ȸ�� �ӵ�
    public AudioClip flapSound;            // ���� ���� (����)

    private Rigidbody2D rb;
    private bool isDead = false;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.gravityScale = 1f; // �߷� ����
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
            rb.velocity = new Vector2(2f, jumpForce); // ƨ�ܳ���
            rb.gravityScale = 2f;                     // �� ������ ����
        }
    }

}
