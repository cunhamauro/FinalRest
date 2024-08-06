using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Animator enemyAnimator;
    public EnemyHealth enemyHealth;
    private NavMeshAgent agent;
    private float attackCooldown = 1f; // Time between attacks in seconds
    private float lastAttackTime = 0f; // Time when the last attack happened
    private float attackDistance = 3f; // Distance at which the enemy attacks
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script
    public AudioSource zombieSource;
    public AudioClip zombieClip;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
        zombieSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            agent.velocity = Vector3.zero;
        }

        if (enemyHealth.health <= 0)
        {
            // Stop movement if the player is dead
            agent.velocity = Vector3.zero;
            return;
        }

        if (playerHealth.health <= 0)
        {
            // Stop movement if the player is dead
            agent.velocity = Vector3.zero;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > attackDistance)
        {
            Debug.Log("Player is safe!");

            // Move towards the player if not within attack range
            agent.destination = player.transform.position;
        }
        else
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Debug.Log("Player is being attacked!");

                // Stop moving and attack if within attack range and attack timming
                agent.velocity = Vector3.zero;

                enemyAnimator.SetTrigger("EnemyAttack");
                zombieSource.Play();
                playerHealth.DamagePlayer(20f);

                lastAttackTime = Time.time; // Update the last attack time
            }
        }
    }
}
