using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : SingleInstance<BuildingManager> {

    private BuildingData _selectedBuildingData;
    public BuildingData SelectedBuildingData {
        get => _selectedBuildingData;
        private set {
            _selectedBuildingData = value;

            if (_selectedBuildingData == null) return;

            _placingBuilding = Instantiate(SelectedBuildingData.building);
            _placingBuilding.SetUpBuilding(SelectedBuildingData);
        }
    }

    [SerializeField] private List<BuildingData> _buildingDatas;
    [SerializeField] private BuildingCarousel _carousel;

    private bool _allowBuildingPlacement = false;
    private BuildingController _placingBuilding;
    private Dictionary<BuildingData, List<Vector3Int>> _buildings;
    private Vector3Int _lastGridPosition;
    private List<Vector3Int> _occupiedGrids;

    private void Awake() {
        _buildings = new Dictionary<BuildingData, List<Vector3Int>>();

        GameStateManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void Start() {
        _carousel.CreateItems(_buildingDatas);
    }

    private void Update() {
        if (!_allowBuildingPlacement) return;
        if (SelectedBuildingData == null) return;

        if (Input.GetMouseButton(0) && !RaycastHelper.IsPointerOverUIObject()) {
            // move building, change color if not available

            _lastGridPosition = GridManager.Instance.GetGridPosition(Input.mousePosition);
            _placingBuilding.transform.position = _lastGridPosition;
            _placingBuilding.SetColor(CheckAvailability() ? Color.green : Color.red, 0.5f);
        }
        if (Input.GetMouseButtonUp(0) && !RaycastHelper.IsPointerOverUIObject()) {
            // save building, change state

            if (CheckAvailability()) {
                PlaceBuilding();

                GameStateManager.Instance.SetGameState(GameState.Game);
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
        _allowBuildingPlacement = newState == GameState.ProductionMenu;
    }

    public void SetSelectedBuildingData(BuildingData buildingData) {
        SelectedBuildingData = buildingData;
    }

    private void PlaceBuilding() {
        _placingBuilding.SetColor(Color.white, 1f);

        _buildings.Add(SelectedBuildingData, _occupiedGrids);

        Debug.Log("placed building count: " + _buildings.Count);

        SelectedBuildingData = null;
        _placingBuilding = null;
    }

    private bool CheckAvailability() {
        _occupiedGrids = new List<Vector3Int>();
        for (int i = 0; i < SelectedBuildingData.buildingDimensions.x; i++) {
            for (int j = 0; j < SelectedBuildingData.buildingDimensions.y; j++) {
                _occupiedGrids.Add(new Vector3Int(_lastGridPosition.x + i, _lastGridPosition.y + j, 0));
            }
        }

        Debug.Log("occupied grid count: " + _occupiedGrids.Count);

        foreach(List<Vector3Int> buildingPosition in _buildings.Values) {
            for (int i = _occupiedGrids.Count - 1; i >= 0; i--) {
                if (buildingPosition.Contains(_occupiedGrids[i])) {
                    return false;
                }
            }
        }

        return true;
    }

}
