using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO
{
    public class Spawner : MonoBehaviour, ISpawner
    {
        private IButtonControl _buttonControl;

        [SerializeField] private GameObject _linePrefab;

        public void Init(IButtonControl buttonControl)
        {
            _buttonControl = buttonControl;

            Subscribe();
        }

        private void Subscribe()
        {
            _buttonControl.ObjectIsBeingCreated += CreateObject;
        }

        public void CreateObject()
        {
            Instantiate(_linePrefab);
        }

        private void OnDestroy()
        {
            _buttonControl.ObjectIsBeingCreated -= CreateObject;
        }
    }
}
