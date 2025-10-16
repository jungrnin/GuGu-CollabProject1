using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;      //�����ϴ� ��      
    public float deathBounceForce = 5f;
    public float deathPushBack = -2f;      //�ڷ� ���ư��� �ӵ�
    public float rotationSpeed = 200f;     //���ư��� �ӵ�

    public AudioSource audioSource;
    public AudioClip jumpSound;

    //�÷��̾ �׾����� ���θ� �����ϴ� �Լ�
    private Rigidbody2D rb;
    private bool isDead = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        //�߷��� ���� ������ �����ϴ� �ڵ�
        rb.gravityScale = 1f;
    }

    void Update()
    {
        if(GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }
        if (!isDead && Input.GetKeyDown(KeyCode.Space))  //�����̽��ٸ� ������ �����Ѵ�
        {
            rb.velocity = Vector2.up * jumpForce;
            if(audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        if (isDead)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);            //�÷��̾ �׾����� ���鼭 �������� ȿ���� ���Ѱ�
        }
    }

    // ���� ����� �� ȣ��Ǵ� �Լ�
    public void DieOnGround()
    {
        if (!isDead)
        {
            isDead = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 2f;
            Debug.Log("���� ��� ��� ó����");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }

}
