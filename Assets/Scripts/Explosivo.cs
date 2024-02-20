using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour
{
    public Transform explosionPoint;
    [SerializeField] private float explosionRange;
    [SerializeField] private float empuje;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("explosivo") || collision.CompareTag("bala") || collision.CompareTag("misilTeled"))
        {
            Explode();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("kunai"))
        {
            Explode();
            collision.GetComponent<Rigidbody2D>().gravityScale = 10;
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRange);

        foreach (Collider2D collider in hitColliders)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null && rb2D != GetComponent<Rigidbody2D>())
            {
                Vector2 direction = collider.transform.position - explosionPoint.position;
                float distance = direction.magnitude;

                if (distance > 0)
                {
                    float force = explosionRange / distance * empuje;
                    rb2D.AddForce(direction.normalized * force, ForceMode2D.Impulse);
                }
            }

            EnemigoRodante enemyScript = collider.GetComponent<EnemigoRodante>();
            if (enemyScript != null)
            {
                enemyScript.TakeExplosionDamage();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(explosionPoint.position, explosionRange);
    }
}
