using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ThreeDimensionalGrid grid;
    [SerializeField] private int mineCount;
    [SerializeField] private int width, height, depth;
    
    void Start()
    {
        //SetCursorVisibility(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        grid.CreateGrid(width, height, depth);
        
        grid.CreateMap(mineCount);
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
        
    }
}
