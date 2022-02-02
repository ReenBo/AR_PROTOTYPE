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
using AR_PROTO.Interface;

namespace AR_PROTO
{
    public class UseObjects : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _listPoints;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _linePrefab;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _cleareButton;

        private GameObject _lineClone;

        private Action<bool> _beingDestroyedEvent;

        private float width = (float)Screen.width / 2.0f;
        private float height = (float)Screen.height / 2.0f;

        public Action<bool> BeingDestroyedEvent { get => _beingDestroyedEvent; }

        protected void Awake()
        {
            _camera = Camera.main;

            _useButton.onClick.AddListener(UseLine);
            _createButton.onClick.AddListener(CreatePoints);
            _createButton.onClick.AddListener(CleareButton);
        }

        protected void Update()
        {
            TestingMouse();
        }

        private void TestingMouse()
        {
            if (Input.GetMouseButton(0))
            {
                var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(mousePos);
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    Debug.Log(hit.transform.name);
                    //hit.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

                    Debug.DrawRay(ray.direction, hit.point, Color.red, 2f);

                    Vector2 pos = Input.mousePosition;
                    pos.x = (pos.x - width) / width;
                    pos.y = (pos.y - height) / height;
                    var position = new Vector3(pos.x, pos.y, 1f);

                    if (hit.transform.GetComponent<Node>())
                    {
                        hit.transform.position = position * hit.point.z;
                    }
                }
            }
        }

        private void CreatePoints()
        {
            for (int i = 0; i < _listPoints.Count; i++)
            {
                var gObj = Instantiate(
                    _listPoints[i],
                    new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-1.7f, 1.7f), 0f),
                    Quaternion.identity);
            }
        }

        private void UseLine()
        {
            _lineClone = Instantiate(_linePrefab);
        }

        private void CleareButton()
        {
            _beingDestroyedEvent.Invoke(true);
        }

        private void OnDisable()
        {
            _useButton.onClick.RemoveListener(UseLine);
            _createButton.onClick.RemoveListener(CreatePoints);
            _createButton.onClick.RemoveListener(CleareButton);
        }
    }
}
