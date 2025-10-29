using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuMethods : MonoBehaviour
{
    // Starts the game and loads the main game scene
    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Closes the game
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
