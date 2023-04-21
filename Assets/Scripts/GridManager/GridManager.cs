using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : SingleInstance<GridManager> {

    [SerializeField] private Tilemap _grid;

    private Camera _mainCamera;

    private void Awake() {
        _mainCamera = Camera.main;
    }

    public Vector3Int GetGridPosition(Vector3 position) {
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(position);
        return _grid.WorldToCell(worldPosition);
    }

    public Vector3Int GetGridPositionWithWorldPosition(Vector3 position) {
        return _grid.WorldToCell(position);
    }

}
