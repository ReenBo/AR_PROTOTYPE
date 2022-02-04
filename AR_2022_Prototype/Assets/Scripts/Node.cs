using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AR_PROTO.Interface;
using UnityEngine.XR.ARFoundation;

namespace AR_PROTO
{
    public class Node : MonoBehaviour, INode
    {
        private int _idNode;

        private SphereCollider _collider;
        private Rigidbody _rigidbody;
        private Renderer _renderer;

        private Transform _nodeTransform;

        private bool _isMoved = true;

        public int IDNode { get => _idNode; set => _idNode = value; }
        public bool IsMoved { get => _isMoved; }
        public Transform NodeTransform { get => _nodeTransform; }

        protected void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            _nodeTransform = GetComponent<Transform>();
        }

        public void Init(ENode id)
        {
            IDNode = (int)id;
        }

        protected void OnTriggerEnter(Collider collider)
        {
            var iNode = collider.GetComponent<INode>();

            if (iNode != null)
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

        public void ChangeColor(bool isSelected)
        {
            Color? thisColor = isSelected ? Color.red : default;

            _renderer.material.color = (Color)thisColor;
        }

        //protected void OnMouseEnter()
        //{
        //    _renderer.material.color = Color.red; 
        //}

        //protected void OnMouseExit()
        //{
        //    _renderer.material.color = default;
        //}
    }
}
