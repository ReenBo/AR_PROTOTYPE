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

        private LineRenderer _line;
        private Transform _nodeStart;
        private Transform _nodeEnd;

        protected void Awake()
        {
            _line = gameObject.GetComponent<LineRenderer>();
            _line.positionCount = 2;

            _nodeStart = GetNodePositionByIndex(_nodePrefab, 0);
            _nodeEnd = GetNodePositionByIndex(_nodePrefab, 1);

            _nodeStart.gameObject.AddComponent<Node>().Init(ENode.nodeS);
            _nodeEnd.gameObject.AddComponent<Node>().Init(ENode.nodeE);
        }

        protected void Update()
        {
            _line.SetPosition(0, _nodeStart.position);
            _line.SetPosition(1, _nodeEnd.position);
        }

        private Transform GetNodePositionByIndex(GameObject gameObject, int index)
        {
            var vector = new Vector3(index, 0f, 2f);

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
