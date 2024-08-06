using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Animator animator;
    public GameObject[] bloodSplats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DamageEnemy(float damage)
    {
        int randomIndex = Random.Range(0, bloodSplats.Length);
        GameObject bloodSplat = Instantiate(bloodSplats[randomIndex], transform.position, Quaternion.identity);

        // Destroy the blood splat after 5 seconds
        Destroy(bloodSplat, 9f);

        health -= damage;
        Debug.Log($"Enemy Health: {health}");

        if (health <= 0)
        {
            animator.SetTrigger("EnemyDeath");
            Destroy(gameObject, 7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
