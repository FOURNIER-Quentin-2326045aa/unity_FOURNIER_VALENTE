using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float chaseDistance = 3f;
    public float stopDistance = 0.5f;
    public float speed = 2f;
    public float damagePerSecond = 10f;

    private GameObject player;
    private PlayerHealth playerHealth;
    private bool attacking = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (player == null || playerHealth == null)
            return;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist <= chaseDistance)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;

            if (dist > stopDistance)
            {
                transform.position += dir * speed * Time.deltaTime;
                transform.LookAt(player.transform);
            }

            if (dist <= stopDistance && !attacking)
            {
                attacking = true;
                StartCoroutine(DealDamage());
            }

            if (dist > stopDistance)
            {
                attacking = false;
            }
        }
    }

    IEnumerator DealDamage()
    {
        while (attacking && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
            yield return null;
        }
    }
}
