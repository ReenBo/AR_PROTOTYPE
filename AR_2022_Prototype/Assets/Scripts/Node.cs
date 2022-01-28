using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO
{
    public class Node : MonoBehaviour
    {
        private SphereCollider _collider;
        private Rigidbody _rigidbody;

        private bool _isMoved = true;

        private const string _sphereTag = "Sphere";

        protected void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                if (other.CompareTag(_sphereTag))
                {
                    _isMoved = false;

                    transform.position = other.transform.position;

                    //other.GetComponent<Collider>().enabled = false;

                    _rigidbody.Sleep();
                    _collider.enabled = false;
                }
            }
        }
    }
}
