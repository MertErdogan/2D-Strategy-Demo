
using System;
using UnityEngine;

public interface IAnimation {

    public RectTransform Rect { get; }
    public Vector3 OutOfViewPosition { get; }
    public Vector3 InViewPosition { get; }
    public float AnimationDuration { get; }

    public void GetInView(bool animate = true, Action OnComplete = null);
    public void GetOutView(bool animate = true, Action OnComplete = null);
    public void KillAnimation();

}