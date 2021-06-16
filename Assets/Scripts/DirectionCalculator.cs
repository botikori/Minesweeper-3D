using System.Collections.Generic;
using UnityEngine;

public static class DirectionCalculator
{
    public static List<Vector3Int> GetNeighbourDirections()
    {
        List<Vector3Int> neighbourDirectionsList = new List<Vector3Int>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    neighbourDirectionsList.Add(new Vector3Int(x, y, z));
                }
            }
        }

        return neighbourDirectionsList;
    }
}