using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("FleetDeath");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScreen");
    }
    public void QuitGame() { 
        Application.Quit();
    }

    public void BackButton() {
        SceneManager.LoadScene("TitleScreen");
    }
}
