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

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = _grid.WorldToCell(worldPosition);

            Debug.Log(cellPosition);
        }
    }

}
