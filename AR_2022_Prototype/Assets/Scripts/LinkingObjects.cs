using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class LinkingObjects : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<GameObject> _listGameObjects;
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Text _touchPosInfo;
    [SerializeField] private GameObject _cursor;

    [SerializeField] private Button _createButton;

    private Vector3 touchPos;
    private GameObject _gObj;
    private RaycastHit raycastHit;

    private float width = (float) Screen.width / 2.0f;
    private float height = (float) Screen.height / 2.0f;

    private bool _isCreated = true;

    private GameObject _instance;

    protected void Awake()
    {
        //_instance = Instantiate(_cursor);

        _createButton.onClick.AddListener(CreatePoints);
    }

    private void Update()
    {
        //CreateLineObject();
        //TestingCreateLine();
    }

    private void CreatePoints()
    {
        for (int i = 0; i < _listGameObjects.Count; i++)
        {
            var gObj = Instantiate(
                _listGameObjects[i],
                new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-1.7f, 1.7f), 0f),
                Quaternion.identity);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    private void TestingCreateLine()
    {
        if (Input.mousePresent)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    _touchPosInfo.text = $"Touch position: {hit.point}";

                    _gObj = Instantiate(
                        _linePrefab,
                        hit.point,
                        Quaternion.identity);

                    raycastHit = hit;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                var position = new Vector3(pos.x, pos.y, 1f);

                if (_gObj != null)
                {
                    _gObj.transform.position = position * raycastHit.point.z;
                }
            }
        }
    }

    private void CreateLineObject()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    _touchPosInfo.text = $"Touch position: {hit.point}";

                    _gObj = Instantiate(
                        _linePrefab,
                        hit.point,
                        Quaternion.identity);

                    raycastHit = hit;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                var position = new Vector3(pos.x, pos.y, 1f);

                if (_gObj != null)
                {
                    _gObj.transform.position = position * raycastHit.point.z;
                }
            }
        }
    }
}
