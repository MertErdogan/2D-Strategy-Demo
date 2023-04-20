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

    public Vector3Int GetGridPosition(Vector3 mousePosition) {
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        return _grid.WorldToCell(worldPosition);
    }

}
