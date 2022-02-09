using AR_PROTO.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO
{
    public class ApplicationStateManagement : IState
    {
        private IButtonControl _buttonControl;
        private INode _node;

        private EState _currentState;

        public ApplicationStateManagement(IButtonControl buttonControl)
        {
            _buttonControl = buttonControl;

            Subscribe();
        }

        private void Subscribe()
        {
            _buttonControl.SwitchesToDrawState += ChangeState;
            _buttonControl.SwitchesToUsingState += ChangeState;
        }

        public void ChangeState(EState state)
        {
            Debug.Log(state.ToString());

            switch (state)
            {
                case EState.Draw:
                    _currentState = EState.Draw;
                    break;
                case EState.Using:
                    _currentState = EState.Using;
                    break;
                default:
                    break;
            }
        }

        public EState GetState()
        {
            return _currentState;
        }
    }
}
