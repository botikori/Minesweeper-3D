using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThreeDimensionalGrid : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private float margin = 0.5f;
    
    private Cell[,,] _grid;
    private int _width, _height, _depth;

    public void CreateGrid(int width, int height, int depth)
    {
        _width = width;
        _height = height;
        _depth = depth;
        
        _grid = new Cell[_width, _height, _depth];
        
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int z = 0; z < _depth; z++)
                {
                    _grid[x, y, z] = CreateCell(x,y,z);
                }
            }    
        }
    }

    private Cell CreateCell(int x, int y, int z)
    {
        Cell cell = Instantiate(cellPrefab, CalculateCellPosition(x,y,z), Quaternion.identity, transform);
        
        cell.MyCellPosition = new Vector3Int(x, y, z);
        cell.IsMine = false;
        cell.IsDiscovered = false;
        cell.IsFlagged = false;
        cell.CellNumber = 0;

        return cell;
    }

    private Vector3 CalculateCellPosition(int x, int y, int z)
    {
        float currentMargin = margin + 1;
        
        Vector3 cellPos = new Vector3(x * currentMargin, y * currentMargin, z * currentMargin);
        return cellPos;
    }
    
    public void CreateMap(int mineCount)
    {
        if (mineCount >= _depth * _width * _height)
        {
            throw new Exception("Too high number for mine count");
        }

        while (mineCount > 0)
        {
            Vector3Int randomCellPosition = 
                new Vector3Int(Random.Range(0, _width), Random.Range(0, _height), Random.Range(0, _depth));
            Cell selectedCell = _grid[randomCellPosition.x, randomCellPosition.y, randomCellPosition.z];
            
            if (!selectedCell.IsMine)
            {
                selectedCell.IsMine = true;
                RaiseNeighbourCells(DirectionCalculator.GetNeighbourDirections(), randomCellPosition.x, randomCellPosition.y, randomCellPosition.z);
                mineCount--;
            }
        }
    }
    
    private void RaiseNeighbourCells(List<Vector3Int> directions, int x, int y, int z)
    {
        foreach (var direction in directions)
        {
            if (direction.x + x >= 0 && direction.y + y >= 0 && direction.z + z >= 0 && direction.x + x < _width && direction.y + y < _height && direction.z + z < _depth)
            {
                Cell cellToRaise = _grid[x + direction.x, y + direction.y, z + direction.z];

                if (!cellToRaise.IsMine)
                {
                    cellToRaise.CellNumber++;
                }
            }
        }
    }

    public void RevealNeighbourCells(List<Vector3Int> directions, int x, int y, int z)
    {
        foreach (var direction in directions)
        {
            if (direction.x + x >= 0 && direction.y + y >= 0 && direction.z + z >= 0 && direction.x + x < _width && direction.y + y < _height && direction.z + z < _depth)
            {
                Cell cellToRevel = _grid[x + direction.x, y + direction.y, z + direction.z];
                
                cellToRevel.DiscoverCell();
            }
        }
    }
}
