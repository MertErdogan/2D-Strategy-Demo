using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateObject : MonoBehaviour {

    [SerializeField] private GameState _targetState;
    [SerializeField] private GameObject _container;
    [SerializeField] private AnimationSequenceController _animationSequenceController;

    private void Awake() {
        GameStateManager.Instance.OnGameStateChanged += HandleGameStateChanged;
        GameStateManager.Instance.OnGameStateChangedFrom += HandleGameStateChangedFrom;
    }

    private void OnDestroy() {
        if (GameStateManager.Instance != null) {
            GameStateManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
            GameStateManager.Instance.OnGameStateChangedFrom -= HandleGameStateChangedFrom;
        }
    }

    private void HandleGameStateChangedFrom(GameState newState, GameState previousState) {
        if (_targetState == newState) {
            if (_animationSequenceController.IsEmpty()) {
                _container.SetActive(true);

                return;
            }

            _container.SetActive(true);
            _animationSequenceController.AppearAnimationSequence();
        } else if (_targetState == previousState) {
            if (_animationSequenceController.IsEmpty()) {
                _container.SetActive(false);

                return;
            }

            _animationSequenceController.DissapearAnimationSequence(() => {
                if (_targetState != GameStateManager.Instance.CurrentGameState) {
                    _container.SetActive(false);
                }
            });
        } else {
            if (_animationSequenceController.IsEmpty()) {
                _container.SetActive(false);

                return;
            }

            _animationSequenceController.DissappearWithoutAnimation();
            _container.SetActive(false);
        }
    }

    private void HandleGameStateChanged(GameState newState) {
        if (newState == GameState.None) {
            _container.SetActive(false);
        }
    }
}
