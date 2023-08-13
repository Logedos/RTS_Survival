using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Vector3 lastPosition;

    [SerializeField] private LayerMask layerMask;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Here");
            lastPosition = hit.point;
        }

        return lastPosition;
    }
}
