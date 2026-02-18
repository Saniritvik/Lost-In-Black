using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureMenu : MonoBehaviour
{
    public string homeScene;
    public string restartScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public void home()
    {
        SceneManager.LoadSceneAsync(homeScene);
        DontDestroy[] objectsWithScript = FindObjectsByType<DontDestroy>(FindObjectsSortMode.None);
        foreach (DontDestroy obj in objectsWithScript)
        {
            Destroy(obj.gameObject);
        }
    }
    public void restart()
    {
        SceneManager.LoadSceneAsync(restartScene);
        DontDestroy[] objectsWithScript = FindObjectsByType<DontDestroy>(FindObjectsSortMode.None);
        foreach (DontDestroy obj in objectsWithScript)
        {
            Destroy(obj.gameObject);
        }
    }
    public void quit()
    {
        Application.Quit();
    }
}
