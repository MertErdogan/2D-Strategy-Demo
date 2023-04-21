using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierInteractionManager : SingleInstance<SoldierInteractionManager> {

    private SoldierController _selectedSoldier;
    public SoldierController SelectedSoldier {
        get => _selectedSoldier;
        private set {
            _selectedSoldier = value;
        }
    }

    private bool _allowSoldierInteraction = false;
    private Camera _mainCamera;

    private void Awake() {
        _mainCamera = Camera.main;

        GameStateManager.Instance.OnGameStateChanged += HandleGamestateChanged;
    }

    private void Update() {
        if (!_allowSoldierInteraction) return;
        if (SelectedSoldier == null) return;

        if (Input.GetMouseButtonDown(1) && !RaycastHelper.IsPointerOverUIObject()) {
            RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null) return;

            if (hit.collider.TryGetComponent(out BuildingController buildingController)) {
                SelectedSoldier.Attack(buildingController);
            } else if (hit.collider.TryGetComponent(out SoldierController soldierController)) {
                if (soldierController == SelectedSoldier) return;

                SelectedSoldier.Attack(soldierController);
            }
        }
    }

    protected override void OnDestroy() {
        if (GameStateManager.Instance != null) {
            GameStateManager.Instance.OnGameStateChanged -= HandleGamestateChanged;
        }

        base.OnDestroy();
    }

    private void HandleGamestateChanged(GameState newState) {
        _allowSoldierInteraction = newState == GameState.SoldierMenu;
    }

    public void SetSelectedSoldier(SoldierController soldier) {
        SelectedSoldier = soldier;
    }

}
