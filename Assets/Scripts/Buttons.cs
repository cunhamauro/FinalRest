using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit()
    {
        // Check if the application is running in the editor or as a build
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
                    Application.Quit(); // Quit the application in a build
        #endif
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
