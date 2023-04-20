using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChanger : MonoBehaviour {

    [SerializeField] private GameState _targetGameState;

    public void ChangeGameState() {
        GameStateManager.Instance.SetGameState(_targetGameState);
    }

}
