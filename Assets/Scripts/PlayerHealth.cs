using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; // Starting health of the player
    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;
    public Animator weaponAnimator;
    public GameObject aim;
    public TextMeshProUGUI healthText;
    public Animator gameUIanimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        Debug.Log($"Player damaged: {damage} | Health: {health}!");

        healthText.text = $"[ Health: {health} ]";
        gameUIanimator.SetTrigger("Attacked");

        if (health <= 0)
        {
            Debug.Log($"Player DIED!");

            // Define the rotation in Euler angles
            Vector3 eulerRotation = new Vector3(14.4071159f, 250.233002f, 264.890503f);

            // Convert Euler angles to Quaternion and set the rotation
            gameObject.transform.rotation = Quaternion.Euler(eulerRotation);

            playerMovement.enabled = false;
            playerWeapon.enabled = false;
            aim.SetActive(false);
            weaponAnimator.SetTrigger("StopGun");
            Debug.Log($"Player controls disabled!");

            gameUIanimator.SetTrigger("Dead");

            Invoke("LoadGameOver", 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverSceneL");
    }
}
