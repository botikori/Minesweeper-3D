using UnityEngine.SceneManagement;

public class GameOverMenu : MenuBase
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menus/StartMenuScene");
    }
}
