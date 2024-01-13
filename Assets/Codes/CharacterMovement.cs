using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [Header("Karakter özellikleri")]
    [Tooltip("Karakterin hýzýdýr.")] public float speed;
    [Tooltip("Karakterin zýplama gücüdür.")] public float jumpPower;

    public float health = 100;
    [SerializeField] int coin = 0;
    [SerializeField] bool hasKey = false;
    bool unlockGate = false;

    [Header("Move Direction")]

    [SerializeField] Vector3 moveDirection;

    private Rigidbody rb;

    [SerializeField] Camera cam;

    [Header("Animation")]

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        animator = transform.Find("BalaHatun").GetComponent<Animator>();
    }
    void Update()
    {
        #region MOVEMENT_PART
        Movement(speed);

        speed = Mathf.Clamp(speed, 15f, 30f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed += 0.1f;
            animator.SetBool("Is Running", true);
        }
        else
        {
            speed -= 0.1f;
            animator.SetBool("Is Running", false);
        }
        #endregion

        health = Mathf.Clamp(health, 0, 100);

        if(unlockGate && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Movement(float movementSpeed)
    {
        float moveX = Input.GetAxis("Vertical");
        float moveY = Input.GetAxis("Horizontal");

        animator.SetFloat("PosX", moveX);
        animator.SetFloat("PosY", moveY);

        moveDirection = new Vector3(moveY * movementSpeed * Time.deltaTime, 0, moveX * movementSpeed * Time.deltaTime);
        transform.position += moveDirection;
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Gate"))
        {
            if (hasKey && coin >= 3)
            {
                unlockGate = true;
            }
        }
        if (col.CompareTag("Coin"))
        {
            coin++;
            Destroy(col.gameObject);
        }
        if (col.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Gate"))
        {
            unlockGate = false;
        }
    }
}
