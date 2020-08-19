﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraFeatures {
    public class CameraFollow : MonoBehaviour
    {
        //Reference Variables
        private Camera cam = null;
        private Transform cameraTransform = null;
        private Transform objectTransform = null;

        //State Variables
        private Vector3 currentPosition;
        private float yOffset = 0f;

        //Scene Change Function
        #region SceneChangedEventCalls
        private void OnEnable() {
            SceneManager.activeSceneChanged += OnSceneChange;     //Subscribe to Event Delegate
        }

        private void OnDisable() {
            SceneManager.activeSceneChanged -= OnSceneChange;     //Unsubscribe from Event Delegate
        }
        #endregion
        private void OnSceneChange(Scene oldScene, Scene newScene) {
            FindCameraObject();
        }

        //Internal Methods
        private void Awake() {
            FindCameraObject();
            GetObjectTransform();
            SetupPositionParameters();
            SetVerticalOffset();
        }

        private void FindCameraObject() {
            cam = Camera.main;
            if (cam is null) {
                Debug.LogError("No Main Camera Found!");
                enabled = false;
            } else {
                cameraTransform = cam.transform;
            }
        }

        private void GetObjectTransform() {
            objectTransform = gameObject.transform;
        }

        private void SetupPositionParameters() {
            currentPosition = objectTransform.position;
        }

        private void SetVerticalOffset() {
            yOffset = currentPosition.y;
        }

        private void LateUpdate() {
            UpdatePosition();
        }

        private void UpdatePosition() {
            currentPosition.y = cameraTransform.position.y + yOffset;
            objectTransform.position = currentPosition;
        }
    }
}
