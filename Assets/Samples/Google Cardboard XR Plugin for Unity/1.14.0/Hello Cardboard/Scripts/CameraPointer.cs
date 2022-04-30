//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 1000;
    private GameObject _gazedAtObject = null;
    private bool Check1 = false;
    public LayerMask layermask;
    public LayerMask layermaskUI;



    private void Start()
    {

    }
    public void ObReset()
    {
        _gazedAtObject = null;
    }
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, layermask))
        {
            //rDebug.Log(hit.transform.name);
            if (hit.transform.CompareTag("GameObject") == false)
            {
                return;
            }
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                //_gazedAtObject?.SendMessage("OnPointerExit");
                //if (_gazedAtObject.TryGetComponent(out ObjectInfo info))
                //{
                //    info.OnPointerExit();
                //}
                if (_gazedAtObject !=null)
                {
                    if (_gazedAtObject.TryGetComponent(out ObjectInfo info))
                    {
                        info.OnPointerExit();
                    }
                }
                _gazedAtObject = hit.transform.gameObject;
                //_gazedAtObject.SendMessage("OnPointerEnter");
                if (_gazedAtObject.TryGetComponent(out ObjectInfo info2))
                {
                    info2.OnPointerEnter();
                }



            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            //if (_gazedAtObject !=null)
            //{
            //_gazedAtObject.SendMessage("OnPointerExit");

            //}
            if (_gazedAtObject!=null)
            {

            if (_gazedAtObject.TryGetComponent(out ObjectInfo info3))
            {
                info3.OnPointerExit();
            }
            }
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            //_gazedAtObject?.SendMessage("OnPointerClick");
            if (_gazedAtObject.TryGetComponent(out ObjectInfo info4))
            {
                info4.OnPointerClick();
            }
            _gazedAtObject = null;

        }
    }
}
