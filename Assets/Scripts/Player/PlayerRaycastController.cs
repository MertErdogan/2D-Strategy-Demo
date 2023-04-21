using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastController : SingleInstance<PlayerRaycastController> {

    private bool _allowRaycast = false;
    private Camera _mainCamera;

    private void Awake() {
        _mainCamera = Camera.main;

        GameStateManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void Update() {
        if (!_allowRaycast) return;

        if (Input.GetMouseButtonDown(0) && !RaycastHelper.IsPointerOverUIObject()) {
            RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null) return;

            if (hit.collider.TryGetComponent(out BuildingController buildingController)) {
                buildingController.BuildingSelected();
            } else if (hit.collider.TryGetComponent(out SoldierController soldierController)) {
                soldierController.SelectSoldier();
            }
        }
    }

    protected override void OnDestroy() {
        if (GameStateManager.Instance != null) {
            GameStateManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
        }

        base.OnDestroy();
    }

    private void HandleGameStateChanged(GameState newState) {
        _allowRaycast = newState == GameState.Game;
    }
}
