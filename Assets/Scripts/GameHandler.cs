using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ThreeDimensionalGrid grid;

    void Start()
    {
        //SetCursorVisibility(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        grid.CreateGrid(Settings.Width, Settings.Height, Settings.Depth);
        
        grid.CreateMap(Settings.MineCount);
    }

    private void SetCursorVisibility(bool visibility)
    {
        Cursor.visible = visibility;
        
        if (visibility)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GameOver()
    {
        SetCursorVisibility(true);
        SceneManager.LoadScene("Scenes/Menus/GameOverMenuScene");
    }
}
