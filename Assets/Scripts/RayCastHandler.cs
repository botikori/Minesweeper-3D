using UnityEngine;

public class RayCastHandler : MonoBehaviour
{
    private Cell _selectedCell;
    
    void Update()
    {
        RaycastHit hit;
        Transform mainCameraTransform = Camera.main.transform;

        if (_selectedCell != null)
        {
            _selectedCell.ToggleHighlight(false);
        }
        
        if (Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit))
        {
            var selected = hit.collider.gameObject.GetComponentInParent<Cell>();
            selected.ToggleHighlight(true);
            _selectedCell = selected;

            if (Input.GetMouseButtonDown(0))
            {
                _selectedCell.DiscoverCell();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _selectedCell.ToggleFlagCell();
            }
        }
        
    }
}