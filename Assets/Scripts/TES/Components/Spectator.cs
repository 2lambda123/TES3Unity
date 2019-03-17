﻿using Demonixis.Toolbox.XR;
using TESUnity.Components.VR;
using UnityEngine;
using UnityEngine.XR;

namespace TESUnity.Components
{
    public sealed class Spectator : MonoBehaviour
    {
        private void Start()
        {
            if (!XRManager.Enabled)
            {
                enabled = false;
                return;
            }
            // Setup RoomScale/Sitted mode.
            XRManager.Instance.TrackingSpaceType = TrackingSpaceType.Stationary;

            var menuComponent = FindObjectOfType<MenuComponent>();

            Debug.Assert(menuComponent != null);

            var canvas = menuComponent.GetComponentInParent<Canvas>();
            GUIUtils.SetCanvasToWorldSpace(canvas, null, 5, 0.015f, 1.7f);

            var laser = GetComponentInChildren<LaserPointer>(true);
            laser.enabled = true;
        }
    }
}