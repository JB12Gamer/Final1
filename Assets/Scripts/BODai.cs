using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BODai : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public static float health = 1.0f;
    public Rigidbody2D BODRB2D;
    private Transform myTransform;
    public float BOD_Thrust = 600.0f;
    public int time = 3;
    public static int boss = 1;
    public Animator animator;
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        BODRB2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - myTransform.position;
        dir.z = 0.0f; // Only needed if objects don't share 'z' value

        if (dir != Vector3.zero)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                                                     Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
        }

        //Move Towards Target
        myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            boss -= 1;
            Debug.Log(boss);
        }
        if (HMove.Encounter)
        {
            moveSpeed = 1;
        }
        animator.SetFloat("speed", moveSpeed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - 0.025f;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HMove.health -= 25;
            Debug.Log("Ouch");
        }
    }
}
