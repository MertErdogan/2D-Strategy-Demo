using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BarracksController : BuildingController {

    [Header("BarracksController")]
    [SerializeField] private List<SoldierData> _soldiers;

    private Vector3Int _soldierSpawnPoint;

    public override void BuildingSelected() {
        base.BuildingSelected();

        BuildingMenuController.Instance.SetBuildingMenuData(BuildingData, true);
        SoldierManager.Instance.CreateSoldierCarouselItems(_soldiers, _soldierSpawnPoint);
    }

    public override void OnBuildingPlaced() {
        SetSpawnPoint();
    }

    private void SetSpawnPoint() {
        Vector3Int middlePosition = GridManager.Instance.GetGridPositionWithWorldPosition(new Vector3(0.1f, 0.1f, 0f));

        float x, y;
        if (transform.position.y > middlePosition.y) {
            // -1
            y = transform.position.y - 1;
        } else {
            // +dimention.height
            y = transform.position.y + BuildingData.buildingDimensions.y;
        }

        if (transform.position.x < middlePosition.x) {
            // +dimention.width
            x = transform.position.x + BuildingData.buildingDimensions.x;
        } else {
            // -1
            x = transform.position.x - 1;
        }

        _soldierSpawnPoint = GridManager.Instance.GetGridPositionWithWorldPosition(new Vector3(x, y, 0f));
    }

}
