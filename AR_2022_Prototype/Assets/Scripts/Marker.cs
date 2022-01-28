using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    [SerializeField] private GameObject _marker;

    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private float width;
    private float height;

    protected void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();

        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        _marker.SetActive(false);
    }

    protected void Update()
    {
        DrawMarker();
    }

    private void DrawMarker()
    {
        _raycastManager.Raycast(new Vector2(width, height), hits, TrackableType.Planes);

        _marker.transform.position = hits[0].pose.position;

        if(hits.Count > 0)
        {
            _marker.SetActive(true);
            _marker.transform.position = hits[0].pose.position;
        }
        else
        {
            _marker.SetActive(false);
        }
    }
}
