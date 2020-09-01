using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Destroy(this.gameObject, 2.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Translate(Vector3.right * 2 * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, 3 * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(this.gameObject, 2.0f);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
