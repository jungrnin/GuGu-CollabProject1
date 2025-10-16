using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;      //점프하는 힘      
    public float deathBounceForce = 5f;
    public float deathPushBack = -2f;      //뒤로 날아가는 속도
    public float rotationSpeed = 200f;     //돌아가는 속도

    public AudioSource audioSource;
    public AudioClip jumpSound;

    //플레이어가 죽었는지 여부를 저장하는 함수
    private Rigidbody2D rb;
    private bool isDead = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        //중력의 영향 정도를 설정하는 코드
        rb.gravityScale = 1f;
    }

    void Update()
    {
        if(GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }
        if (!isDead && Input.GetKeyDown(KeyCode.Space))  //스페이스바를 누르면 점프한다
        {
            rb.velocity = Vector2.up * jumpForce;
            if(audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        if (isDead)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);            //플레이어가 죽었을때 돌면서 떨어지는 효과를 위한것
        }
    }

    // 땅에 닿았을 때 호출되는 함수
    public void DieOnGround()
    {
        if (!isDead)
        {
            isDead = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 2f;
            Debug.Log("땅에 닿아 사망 처리됨");
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
