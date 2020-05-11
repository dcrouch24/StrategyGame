using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void EndGame()
    {
        Application.Quit();
    }
}
