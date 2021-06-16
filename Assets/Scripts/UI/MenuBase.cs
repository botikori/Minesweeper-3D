using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBase : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}