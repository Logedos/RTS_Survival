using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuildingCollider : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private string buildingTag;

    private void Start()
    {
        buildingManager = GameObject.Find("BuildingSystem").GetComponent<BuildingManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(buildingTag))
        buildingManager.CanPlace = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(buildingTag))
        buildingManager.CanPlace = true;
    }
}
