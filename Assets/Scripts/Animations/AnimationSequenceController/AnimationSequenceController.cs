using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AnimationSequenceController : MonoBehaviour {

    [SerializeField] private List<AnimationSequenceObject> _animationSequences;

    private CanvasGroup _canvasGroup;
    private Coroutine _animationCoroutine;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void ToggleCanvasGroup(bool enabled) {
        _canvasGroup.blocksRaycasts = enabled;
    }

    public bool IsEmpty() {
        return _animationSequences.Count == 0;
    }

    #region Appear Handles

    public void AppearAnimationSequence() {
        ToggleCanvasGroup(false);

        if (_animationCoroutine != null) {
            StopCoroutine(_animationCoroutine);

            for (int i = _animationSequences.Count; i < 0; i--) {
                _animationSequences[i].IAnimation.KillAnimation();
            }
        }

        _animationCoroutine = StartCoroutine(AppearInSequence());
    }

    public void AppearWithoutAnimation() {
        for (int i = 0; i < _animationSequences.Count; i++) {
            _animationSequences[i].IAnimation.GetInView(false);
        }
    }

    #endregion

    #region Dissapear Handles

    public void DissapearAnimationSequence(Action OnComplete = null) {
        ToggleCanvasGroup(false);

        if (_animationCoroutine != null) {
            StopCoroutine(_animationCoroutine);

            for (int i = _animationSequences.Count; i < 0; i--) {
                _animationSequences[i].IAnimation.KillAnimation();
            }

            //OnComplete?.Invoke();
        }

        _animationCoroutine = StartCoroutine(DissapearInSequence(OnComplete));
    }

    public void DissappearWithoutAnimation() {
        for (int i = 0; i < _animationSequences.Count; i++) {
            _animationSequences[i].IAnimation.GetOutView(false);
        }
    }

    #endregion

    private IEnumerator AppearInSequence() {
        for (int i = 0; i < _animationSequences.Count; i++) {
            _animationSequences[i].IAnimation.GetInView();

            yield return new WaitForSecondsRealtime(_animationSequences[i].appearDelay);
        }

        ToggleCanvasGroup(true);

        _animationCoroutine = null;
    }

    private IEnumerator DissapearInSequence(Action OnComplete = null) {
        for (int i = 0; i < _animationSequences.Count; i++) {
            if (i == _animationSequences.Count - 1) {
                _animationSequences[i].IAnimation.GetOutView(true, OnComplete);
            } else {
                _animationSequences[i].IAnimation.GetOutView();
            }

            yield return new WaitForSecondsRealtime(_animationSequences[i].disappearDelay);
        }

        ToggleCanvasGroup(true);

        _animationCoroutine = null;
    }

}
