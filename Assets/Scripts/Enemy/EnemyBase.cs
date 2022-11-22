using Platformer.Hero;
using Sirenix.OdinInspector.Editor.Drawers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 movement;

    public float enemyBaseSpeed = 5f;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Hero");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy() {
        if(target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
           // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           // Debug.Log(target.transform.right);
           // Debug.Log(direction);
            direction.Normalize();
            movement = direction;
        } 
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        moveCharater(movement);
    }
    
    void moveCharater(Vector2 dirction)
    {
        rb.MovePosition((Vector2)transform.position + dirction * enemyBaseSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            collision.GetComponent<HeroController>().TakeDamage();
        }
    }
}
