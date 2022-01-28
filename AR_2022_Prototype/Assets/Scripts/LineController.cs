using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;


namespace AR_PROTO
{
    public class LineController : MonoBehaviour
    {
        [SerializeField] private GameObject _nodePrefab;

        private Camera _camera;

        private LineRenderer _line;
        private Transform _node_start;
        private Transform _node_end;

        protected void Awake()
        {
            _camera = Camera.main;

            _line = gameObject.GetComponent<LineRenderer>();
            _line.positionCount = 2;

            _node_start = GetNodePositionByIndex(_nodePrefab, 0);
            _node_end = GetNodePositionByIndex(_nodePrefab, 1);

            _node_start.gameObject.AddComponent<Node>();
            _node_end.gameObject.AddComponent<Node>();
        }

        protected void FixedUpdate()
        {
            _line.SetPosition(0, _node_start.position);
            _line.SetPosition(1, _node_end.position);
        }

        private Transform GetNodePositionByIndex(GameObject gameObject, int index)
        {
            var vector = new Vector3(index, 0f, 0f);

            var node = Instantiate(gameObject, vector, Quaternion.identity);
            return node.transform;
        }

        //protected void FixedUpdate()
        //{
        //    if (_isMoved)
        //    {
        //        MoveObjects();
        //    }
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other != null)
        //    {
        //        if (other.CompareTag(_sphereTag))
        //        {
        //            _isMoved = false;

        //            transform.position = other.transform.position;
        //            transform.SetParent(other.transform);

        //            other.GetComponent<Collider>().enabled = false;

        //            _rigidbody.Sleep();
        //            _collider.enabled = false;
        //        }
        //    }
        //}

        //private void MoveObjects()
        //{
        //    if (Input.touchCount > 0)
        //    {
        //        var touch = Input.GetTouch(0);

        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            Ray ray = _camera.ScreenPointToRay(touch.position);

        //            if (Physics.Raycast(ray, out RaycastHit hit))
        //            {
        //                transform.position = hit.point;
        //            }
        //        }
        //    }
        //}
    }
}
