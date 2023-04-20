using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionAnimation : MonoBehaviour, IAnimation {

    public RectTransform Rect => transform as RectTransform;
    public Vector3 OutOfViewPosition => _outOfViewPosition;
    public Vector3 InViewPosition => _inViewPosition;
    public float AnimationDuration => _animationDuration;

    [SerializeField] private Vector3 _outOfViewPosition;
    [SerializeField] private float _animationDuration;

    private Vector3 _inViewPosition;

    private void Awake() {
        _inViewPosition = Rect.anchoredPosition;
    }

    private void Reposition(Vector3 position, bool animate, Action OnComplete) {
        if (!animate) {
            Rect.anchoredPosition = position;

            return;
        }

        Rect.DOKill();
        Rect.DOAnchorPos(position, _animationDuration).SetEase(Ease.InOutSine).OnComplete(() => {
            OnComplete?.Invoke();
        });
    }

    #region IAnimation

    public void GetInView(bool animate = true, Action OnComplete = null) {
        gameObject.SetActive(true);

        Reposition(_inViewPosition, animate, OnComplete);
    }

    public void GetOutView(bool animate = true, Action OnComplete = null) {
        Reposition(_outOfViewPosition, animate, () => {
            OnComplete?.Invoke();

            gameObject.SetActive(false);
        });
    }

    public void KillAnimation() {
        Rect.DOKill();
    }

    #endregion

}
