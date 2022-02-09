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
    public class ButtonControl : MonoBehaviour, IButtonControl
    {
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _cleareButton;

        private bool _isSelected = false;

        public event Action ObjectIsBeingCreated;
        public event Action<EState> SwitchesToDrawState;
        public event Action<EState> SwitchesToUsingState;
        public event Action<bool> BeingDestroyed;

        protected void Awake()
        {
            _useButton.onClick.AddListener(UseLine);
            _createButton.onClick.AddListener(CreateLine);
            _createButton.onClick.AddListener(CleareObjectsInScene);
        }

        private void CreateLine()
        {
            ObjectIsBeingCreated.Invoke();
            SwitchesToDrawState.Invoke(EState.Draw);
        }

        private void UseLine()
        {
            SwitchesToUsingState.Invoke(EState.Using);
        }

        private void CleareObjectsInScene()
        {
            //BeingDestroyed.Invoke(true);
        }

        protected void OnDisable()
        {
            _useButton.onClick.RemoveListener(UseLine);
            _createButton.onClick.RemoveListener(CreateLine);
            _createButton.onClick.RemoveListener(CleareObjectsInScene);
        }
    }
}
