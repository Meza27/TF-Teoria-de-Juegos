using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject weaponAreaPrefab;
    public float moveForce = 20f, maxVelocity = 4f;
    private Rigidbody2D body;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        PlayerWalkKeyboard();
        PlayerAttackKeyboard();
    }
    void PlayerWalkKeyboard()
    {
        if (isAttacking) return;
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        float velX = Mathf.Abs(body.linearVelocity.x);
        float velY = Mathf.Abs(body.linearVelocity.x);
        float forceX = 0f, forceY = 0f;
        if (hor > 0)
        {
            if (velX < maxVelocity)
            {
                forceX = moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = 3f;
            transform.localScale = scale;
            animator.Play("Running");
        }

        else if (hor < 0)
        {
            if (velX < maxVelocity)
            {
                forceX = -moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = -3f;
            transform.localScale = scale;
            animator.Play("Running");
        }
        if (ver > 0)
        {
            if (velY < maxVelocity)
            {
                forceY = moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.y = 3f;
            transform.localScale = scale;
            animator.Play("Running");
        }
        if (ver < 0)
        {
            if (velY < maxVelocity)
            {
                forceY = -moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.y = 3f;
            transform.localScale = scale;
            animator.Play("Running");
        }
        else if (hor == 0 && ver == 0)
        {
            animator.Play("Idle");
        }

        body.AddForce(new Vector2(forceX, forceY));
    }

    void PlayerAttackKeyboard()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            isAttacking = true;
            animator.Play("Attack");
            SpawnWeaponArea();
        }
        else
        {
            isAttacking = false;
        }
    }
    void SpawnWeaponArea()
    {
        Vector3 spawnPos = transform.position + new Vector3(transform.localScale.x * 0.1f, 0f, 0f); // Offset in front
        Instantiate(weaponAreaPrefab, spawnPos, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("zona"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Nivel 1");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
