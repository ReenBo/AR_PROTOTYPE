using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AR_PROTO.Interface;
using UnityEngine.XR.ARFoundation;

namespace AR_PROTO
{
    public class Node : MonoBehaviour, INode
    {
        INode node;

        private ARRaycastManager _raycastManager;
        private SphereCollider _collider;
        private Rigidbody _rigidbody;
        private Camera _camera;

        private bool _isMoved = true;

        protected void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }

        protected void Update()
        {
            if (_isMoved)
            {
                MoveObjects();
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            node = collider.GetComponent<INode>();

            if (node != null)
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

        private void MoveObjects()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Ray ray = _camera.ViewportPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        transform.position = hit.point;
                    }
                }
            }
        }
    }
}
