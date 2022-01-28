using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

public class SimpleClass : MonoBehaviour
{
    [Header("Primary")]
    [SerializeField] private GameObject _burgerPrefab;
    [SerializeField] private GameObject _marker;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Image _popup;
    [SerializeField] private ARRaycastManager _raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch _touch;
    private Vector3 position;

    private float width;
    private float height;

    private bool _isOpen = false;

    protected void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        position = Vector3.forward;

        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    protected void Update()
    {
        DrawMarker();
        //GetObject();
        //MoveObjects();
    }

    private void DrawMarker()
    {
        _raycastManager.Raycast(new Vector2(width, height), hits, TrackableType.Planes);

        _marker.transform.position = hits[0].pose.position;
    }

    private void GetObject()
    {
        //if (Input.touchCount == 0)
        //{
        //    return;
        //}

        //if (_raycastManager.Raycast(new Vector2(width, height), 
        //    hits, TrackableType.All))
        //{
        //    Debug.Log(hits[0].trackable.transform.name);

        //    if(_burgerPrefab.transform.position == hits[0].pose.position)
        //    {
        //        _isOpen = true;
        //        _popup.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        _isOpen = false;
        //        _popup.gameObject.SetActive(false);
        //    }
        //}
    }

    private void MoveObjects()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = _touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x, pos.y, 1f);

                _burgerPrefab.transform.position = position;
            }
        }
    }

    private void Open()
    {
        _isOpen = true;
        _popup.gameObject.SetActive(true);
    }

    private void Close()
    {
        _isOpen = false;
        _popup.gameObject.SetActive(false);
    }
}
