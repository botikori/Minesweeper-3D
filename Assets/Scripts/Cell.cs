using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cellSprite;
    [SerializeField] private TextMesh cellText;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Material[] materials;

    public Vector3Int MyCellPosition { get; set; }
    public bool IsMine { get; set; }
    public int CellNumber { get; set; }
    public bool IsDiscovered { get; set; }
    public bool IsFlagged { get; set; }

    private ThreeDimensionalGrid _grid;
    private Camera _camera;
    private GameHandler _gameHandler;
    
    private void Awake()
    {
        _camera = Camera.main;
        _grid = GetComponentInParent<ThreeDimensionalGrid>();
        _gameHandler = GetComponent<GameHandler>();
    }

    private void Update()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        cellText.gameObject.transform.LookAt(_camera.transform);
        cellSprite.gameObject.transform.LookAt(_camera.transform);
    }

    public void ToggleFlagCell()
    {
        if (IsDiscovered) return;
        
        IsFlagged = !IsFlagged;

        if (IsFlagged)
        {
            cellSprite.gameObject.SetActive(true);
            cellSprite.sprite = sprites[1];
        }
        else
        {
            cellSprite.gameObject.SetActive(false);
        }
    }

    public void ToggleHighlight(bool highlight)
    {
        if (highlight)
        {
            gameObject.GetComponentInChildren<Renderer>().material = materials[1];
        }
        else
        {
            gameObject.GetComponentInChildren<Renderer>().material = materials[0];
        }
        
    }
    
    public void DiscoverCell()
    {
        if (IsFlagged) return;
        if (IsDiscovered) return;
        
        IsDiscovered = true;
        
        if (IsMine)
        {
            //TODO GameOver
            Debug.Log("Game over! :(");
            cellText.gameObject.SetActive(false);
            cellSprite.gameObject.SetActive(true);
            cellSprite.sprite = sprites[0];
        }
        else if (CellNumber == 0)
        {
            _grid.RevealNeighbourCells(DirectionCalculator.GetNeighbourDirections(), MyCellPosition.x, MyCellPosition.y, MyCellPosition.z);
            
            cellText.gameObject.SetActive(false);
            cellSprite.gameObject.SetActive(false);
        }
        else
        {
            cellText.gameObject.SetActive(true);
            cellText.text = CellNumber.ToString();
        }
    }
}
