using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool CanPlace = true;
    
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private LayerMask layerMask;

    private GameObject selectedBuild;
    private Vector3 spawnPlace;
    private bool mouseOnSpawnPlace;
    void Update()
    {
        if (selectedBuild is not null)
        {
            selectedBuild.transform.position = spawnPlace;

            if (Input.GetMouseButton(0) && CanPlace && mouseOnSpawnPlace)
            {
                selectedBuild = null;
            }
        }
        
        Debug.Log(selectedBuild is null? "Null" : "Not Null");
        Debug.Log(CanPlace);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray,out hit,1000,layerMask))
        {
            spawnPlace = hit.point;
            mouseOnSpawnPlace = true;
        }
        else
        {
            mouseOnSpawnPlace = false;
        }
    }

    public void SelectBuildings(int index)
    {
        if (selectedBuild is null)
        {
            selectedBuild = Instantiate(buildings[index]);
        }
    }
}
