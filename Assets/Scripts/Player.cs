using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Посилання на компоненти
    private Rigidbody2D rb;
    private Animator animator;

    // Налаштування руху
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject gameControl;
    

    private bool isGrounded;

    void Start()
    {
        // Ініціалізація компонентів
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameControl = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            Debug.Log("Fruit");
            gameControl.GetComponent<GameControl>().FruitsQuantity--;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Dead();
        }
    }

    void Dead()
    {
        Physics2D.IgnoreLayerCollision(6, 3, true);
        Debug.Log("You Dead)");
    }

    void Update()
    {
        
        // Перевірка, чи персонаж на землі
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        // Переміщення персонажа
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetTrigger("Run");
        }
        else if (moveInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetTrigger("Run");
        }
        else if(moveInput == 0)
        {
            animator.SetTrigger("Idle");
        }



        // Перевірка стрибка
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           


        }
        

    }
}
