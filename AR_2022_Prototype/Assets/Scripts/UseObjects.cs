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

        private List<GameObject> _listClonePoints = new List<GameObject>();
        private GameObject _lineClone;

        private Action<bool> _beingDestroyedEvent;

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

        }

        private void UseLine()
        {
            _lineClone = Instantiate(_linePrefab);
            Debug.Log(_lineClone.gameObject.name);
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

        private void CleareButton()
        {
            _beingDestroyedEvent.Invoke(true);
        }
    }
}
