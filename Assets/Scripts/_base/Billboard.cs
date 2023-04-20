﻿using UnityEngine;

public enum PivotAxis
{
    // Most common options, preserving current functionality with the same enum order.
    XY,
    Y,
    // Rotate about an individual axis.
    X,
    Z,
    // Rotate about a pair of axes.
    XZ,
    YZ,
    // Rotate about all axes.
    Free
}

/// <summary>
/// The Billboard class implements the behaviors needed to keep a GameObject oriented towards the user.
/// </summary>
public class Billboard : MonoBehaviour
{
    /// <summary>
    /// The axis about which the object will rotate.
    /// </summary>
    [Tooltip("Specifies the axis about which the object will rotate.")]
    public PivotAxis pivotAxis = PivotAxis.XY;
    public PivotAxis PivotAxis {
        get { return pivotAxis; }
        set { pivotAxis = value; }
    }

    public Transform mainCamera;

    /// <summary>
    /// The target we will orient to. If no target is specified, the main camera will be used.
    /// </summary>
    [Tooltip("Specifies the target we will orient to. If no target is specified, the main camera will be used.")]
    private Transform targetTransform;
    public Transform TargetTransform {
        get { return targetTransform; }
        set { targetTransform = value; }
    }

    private void OnEnable() {
        if (TargetTransform == null) {
            TargetTransform = Camera.main.transform;
        }

        Update();
    }

    /// <summary>
    /// Keeps the object facing the camera.
    /// </summary>
    private void Update() {
        if (TargetTransform == null) {
            return;
        }

        // Get a Vector that points from the target to the main camera.
        Vector3 directionToTarget = TargetTransform.position - transform.position;
        Vector3 targetUpVector = Vector3.up;
        if (mainCamera == null) {
            if (Camera.main != null) {
                targetUpVector = Camera.main.transform.up;
            } else {
                var go = GameObject.FindGameObjectWithTag("360Camera");
                if (go != null) {
                    targetUpVector = go.transform.up;
                } else {
                    Debug.Log("---------------No Camera To Look At----------------");
                }
            }
        } else {
            targetUpVector = mainCamera.up;
        }



        // Adjust for the pivot axis.
        switch (PivotAxis) {
            case PivotAxis.X:
                directionToTarget.x = 0.0f;
                targetUpVector = Vector3.up;
                break;

            case PivotAxis.Y:
                directionToTarget.y = 0.0f;
                targetUpVector = Vector3.up;
                break;

            case PivotAxis.Z:
                directionToTarget.x = 0.0f;
                directionToTarget.y = 0.0f;
                break;

            case PivotAxis.XY:
                targetUpVector = Vector3.up;
                break;

            case PivotAxis.XZ:
                directionToTarget.x = 0.0f;
                break;

            case PivotAxis.YZ:
                directionToTarget.y = 0.0f;
                break;

            case PivotAxis.Free:
            default:
                // No changes needed.
                break;
        }

        // If we are right next to the camera the rotation is undefined. 
        if (directionToTarget.sqrMagnitude < 0.001f) {
            return;
        }

        // Calculate and apply the rotation required to reorient the object
        transform.rotation = Quaternion.LookRotation(-directionToTarget, targetUpVector);
    }

   
}