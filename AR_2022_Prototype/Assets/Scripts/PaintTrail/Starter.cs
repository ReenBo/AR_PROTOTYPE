using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO
{
    public class Starter : MonoBehaviour
    {
        private IButtonControl _buttonControl;
        private ISpawner _spawner;
        private IState _state;

        [SerializeField] GameObject _buttonControlPrefab;
        [SerializeField] GameObject _spawnerPrefab;

        protected void Awake()
        {
            _buttonControl = Instantiate(_buttonControlPrefab).GetComponent<IButtonControl>();

            _spawner = Instantiate(_spawnerPrefab).GetComponent<ISpawner>();
            _spawner.Init(_buttonControl);

            _state = new ApplicationStateManagement(_buttonControl);
        }
    }
}
