using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private GameObject CellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Grid grid;
    private void Update()
    {
        Vector3 mouserPos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPos = grid.WorldToCell(mouserPos);
        mouseIndicator.transform.position = mouserPos;
        CellIndicator.transform.position = grid.CellToWorld(gridPos);

    }
}
