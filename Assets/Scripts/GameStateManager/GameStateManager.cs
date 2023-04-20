using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : SingleInstance<GameStateManager> {

    public Action<GameState> OnGameStateChanged;
    public Action<GameState, GameState> OnGameStateChangedFrom;

    private GameState _currentGameState = GameState.None;
    public GameState CurrentGameState {
        get => _currentGameState;
        private set {
            if (_currentGameState == value) return;

            GameState previousState = _currentGameState;
            _currentGameState = value;

            OnGameStateChangedFrom?.Invoke(_currentGameState, previousState);
            OnGameStateChanged?.Invoke(_currentGameState);
        }
    }

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    private void Start() {
        SetGameState(GameState.Game);
    }

    public void SetGameState(GameState state) {
        CurrentGameState = state;
    }

}
