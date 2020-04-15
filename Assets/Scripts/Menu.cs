using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] MenuComponents menuComponents;

    private void Start()
    {
        menuComponents.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            menuComponents.gameObject.SetActive(true);
            Time.timeScale = 0.2f;
        }
    }

    public void ResumeGame()
    {
        menuComponents.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
