using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HMove : MonoBehaviour
{
    public Animator animator;
    public float HorizontalSpeed = 0.2f;
    public float m_Thrust = 300.0f;
    public Rigidbody2D m_Rigidbody;
    public float h;
    public static int health;
    public static bool player;
    public static bool Encounter;
    public static bool Encounter2;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        health = 100;
        player = true;

    }
    void Update()
    {

        if (m_Rigidbody.velocity.y > 0.1 || m_Rigidbody.velocity.y < -0.1)
        {
            animator.SetBool("InAir", true);
            animator.SetBool("Crouch", false);
            animator.SetBool("OnGround", false);
        }
        else
        {
            animator.SetBool("InAir", false);
            animator.SetBool("OnGround", true);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_Rigidbody.AddForce(transform.up * m_Thrust);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) & animator.GetBool("OnGround"))
        {
            animator.SetBool("Crouch", true);
            h = HorizontalSpeed * Input.GetAxis("Horizontal") * 30.0f;
            animator.SetFloat("Speed", Mathf.Abs(h));
            transform.Translate(h * Time.deltaTime, 0, 0);
        }
        else
        {
            animator.SetBool("Crouch", false);
            h = HorizontalSpeed * Input.GetAxis("Horizontal") * 50.0f;
            animator.SetFloat("Speed", Mathf.Abs(h));
            transform.Translate(h * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("left"))
        {

            Vector2 scaleChange = new Vector2(-5.4f, 5.4f);
            transform.localScale = scaleChange;
        }
        else if (Input.GetKey("right"))
        {
            Vector2 scaleChange = new Vector2(5.4f, 5.4f);
            transform.localScale = scaleChange;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }
        if (health < 1)
        {
            animator.SetBool("Death", true);
            StartCoroutine(Death());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "Encounter1")
        {
            Debug.Log("Boss");
            Encounter = true;
        }
        if (collision.gameObject.tag == "Encounter2")
        {
            Debug.Log("slime");
            Encounter2 = true;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            health -= 10;
            Debug.Log("Ouch");
        }
        if (collision.gameObject.tag == "TestSkull")
        {
            health -= 100;
            Debug.Log("skull");
        }
    }
    void attack()
    {
        animator.SetTrigger("Attack");

    }
    IEnumerator Death()
    {
        Debug.Log("Died");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        player = false;
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }
}