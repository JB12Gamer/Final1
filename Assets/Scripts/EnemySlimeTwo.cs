using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeTwo : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public static float health = 1.0f;
    public Rigidbody2D SRB2D;
    private Transform myTransform;
    public float S_Thrust = 600.0f;
    public int time = 3;

    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        SRB2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Bounce());

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
            EnemySlime.slime -= 1;
            Debug.Log(EnemySlime.slime);
        }
        if (HMove.Encounter2)
        {
            moveSpeed = 2;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = health - 0.34f;
        }
    }
    IEnumerator Bounce()
    {
        while (true)
        {
            Debug.Log("bounce");
            SRB2D.AddForce(transform.up * S_Thrust);
            yield return new WaitForSeconds(time);
            Debug.Log("Bounce Done");
        }

    }
}

