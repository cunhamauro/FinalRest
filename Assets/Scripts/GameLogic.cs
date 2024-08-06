using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllEnemiesDead())
        {
            Invoke("LoadGameOver", 3f);
        }
    }

    private bool AllEnemiesDead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");

        foreach (GameObject enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null && enemyHealth.health > 0)
            {
                return false;
            }
        }
        return true;
    }

    public void LoadGameOver()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneManager.LoadScene("GameScene2");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            SceneManager.LoadScene("GameScene3");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            SceneManager.LoadScene("GameOverSceneW");
        }
    }
}
