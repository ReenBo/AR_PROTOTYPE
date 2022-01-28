using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

public class ShelfWithFoods : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listFoods;
    [SerializeField] private Transform[] _targetPositions;

    [SerializeField] private Camera _aRCamera;
    [SerializeField] private GameObject _popup;

    protected void Awake()
    {
        for (int i = 0; i < _targetPositions.Length; i++)
        {
            Instantiate(_listFoods[i], _targetPositions[i].position, Quaternion.identity);
        }
    }

    protected void FixedUpdate()
    {
        TrackingTouch();
    }

    private void TrackingTouch()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var ray = _aRCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.DrawRay(ray.direction, hit.point, Color.red, 2f);

                    ShowInfoAboutTheObject(hit);
                }
            }
        }
    }

    private void ShowInfoAboutTheObject(RaycastHit hit)
    {
        var popup = Instantiate(_popup, hit.transform.position, hit.transform.rotation);
        popup.transform.SetParent(hit.transform);
        popup.transform.localPosition = new Vector2(0.1f, 0.1f);

        var textMesh = popup.GetComponentInChildren<TextMesh>();
        textMesh.text = $"This is the {hit.collider.tag}";
    }
}
