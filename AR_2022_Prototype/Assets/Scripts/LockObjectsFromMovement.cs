using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class LockObjectsFromMovement : MonoBehaviour
{
    [SerializeField] private Text _gyroInfo;
    [SerializeField] private List<GameObject> _listGameObjects;
    [SerializeField] private Camera _aRCamera;

    private Gyroscope _gyroscope;

    protected void Awake()
    {
        _gyroscope = Input.gyro;

        var parentGameObject = Instantiate(new GameObject("Parent"));

        for (int i = 0; i < _listGameObjects.Count; i++)
        {
            var gObj = Instantiate(
                _listGameObjects[i],
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 2f), 
                Quaternion.identity);

            gObj.isStatic = true;

            gObj.transform.SetParent(parentGameObject.transform);
        }


    }



    protected void FixedUpdate()
    {
        _gyroInfo.text = $"Attitude: {_gyroscope.attitude}";


        //if(_gyroscope.attitude != Quaternion.identity)
        //{
        //    _gyroscope.enabled = false;
        //}
    }
}
