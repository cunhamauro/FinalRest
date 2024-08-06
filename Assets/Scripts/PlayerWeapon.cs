using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject playerWeapon;
    public Animator animator;
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletHitEnemy;
    public ParticleSystem bulletHitMap;
    public AudioSource gunshotSource;
    public AudioClip gunshotClip;

    // Start is called before the first frame update
    void Start()
    {
        gunshotSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;

        if (Input.GetMouseButtonDown(0))
        {
            gunshotSource.PlayOneShot(gunshotClip);
            muzzleFlash.Play();

            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Debug.Log("Object was hit!");

                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

                if (enemy != null)
                {
                    if (hit.collider is SphereCollider)
                    {
                        enemy.DamageEnemy(100f);
                        Debug.Log("HEADSHOT!");
                    }
                    else
                    {
                        enemy.DamageEnemy(10f);
                        Debug.Log("Body shot!");
                    }

                    Instantiate(bulletHitEnemy, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else
                {
                    Instantiate(bulletHitMap, hit.point, Quaternion.LookRotation(hit.normal));

                }
            }

            animator.SetTrigger("FireGun");
        }
    }
}
