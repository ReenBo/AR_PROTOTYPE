using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

public class ARCursor : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    [SerializeField] private GameObject _objectToPlace;
    [SerializeField] private ARRaycastManager _raycastManager;

    private bool useCursor = true;

    //private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    protected void Awake()
    {
        _cursor.SetActive(useCursor);
    }

    protected void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }
    }

    private void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenPosition, hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

    private void CreateObject()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (useCursor)
            {
                Instantiate(_objectToPlace, transform.position, transform.rotation);
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                _raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
                
                if(hits.Count > 0)
                {
                    Instantiate(_objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        }
    }
}
