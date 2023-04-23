using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BarracksController : BuildingController {

    public Vector3Int SoldierSpawnPoint { get; private set; }

    [Header("BarracksController")]
    [SerializeField] private List<SoldierData> _soldiers;

    public override void BuildingSelected() {
        base.BuildingSelected();

        BuildingMenuController.Instance.SetBuildingMenuData(BuildingData, true);
        SoldierManager.Instance.CreateSoldierCarouselItems(_soldiers, SoldierSpawnPoint);
    }

    public override void OnBuildingPlaced() {
        SetSpawnPoint();
    }

    private void SetSpawnPoint() {
        Vector3Int middlePosition = GridManager.Instance.GetGridPositionWithWorldPosition(new Vector3(0.1f, 0.1f, 0f));

        float x, y;
        if (transform.position.y > middlePosition.y) {
            y = transform.position.y - 1;
        } else {
            y = transform.position.y + BuildingData.buildingDimensions.y;
        }

        if (transform.position.x < middlePosition.x) {
            x = transform.position.x + BuildingData.buildingDimensions.x;
        } else {
            x = transform.position.x;
        }

        SoldierSpawnPoint = GridManager.Instance.GetGridPositionWithWorldPosition(new Vector3(x, y, 0f));
    }

}
