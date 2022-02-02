using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AR_PROTO.Interface;
using UnityEngine.XR.ARFoundation;

namespace AR_PROTO
{
    public class Node : MonoBehaviour, INode
    {
        private INode _iNode;
        private int _idNode;

        private ARRaycastManager _raycastManager;
        private SphereCollider _collider;
        private Rigidbody _rigidbody;
        private Camera _camera;

        private bool _isMoved = true;

        public int IDNode { get => _idNode; set => _idNode = value; }

        protected void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }

        public void Init(ENode id)
        {
            IDNode = (int)id;
        }

        protected void Update()
        {
            if (_isMoved)
            {
                //MoveObjects();
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            _iNode = collider.GetComponent<INode>();

            if (_iNode != null)
            {
                PutObjectToSleep(collider);
            }
        }

        private void PutObjectToSleep(Collider nodeCollider)
        {
            _isMoved = false;

            transform.position = nodeCollider.transform.position;

            _rigidbody.Sleep();
            _collider.enabled = false;
        }

        private void TestingMouse()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    Debug.Log(hit.transform.name);

                    Debug.DrawRay(ray.direction, hit.point, Color.red, 2f);
                }
            }
        }

        //private void MoveObjects()
        //{
        //    if (Input.touchCount > 0)
        //    {
        //        var touch = Input.GetTouch(0);

        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            Ray ray = _camera.ViewportPointToRay(touch.position);

        //            if (Physics.Raycast(ray, out RaycastHit hit))
        //            {
        //                transform.position = hit.point;
        //            }
        //        }
        //    }
        //}
    }
}
