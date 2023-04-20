using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCarouselItem : CarouselItem<BuildingData> {

    [SerializeField] private Button _selectionButton;
    [SerializeField] private TextMeshProUGUI _buildingNameText;

    private void Awake() {
        _selectionButton.onClick.AddListener(HandleSelectionButtonClick);
    }

    private void OnDestroy() {
        _selectionButton.onClick.RemoveAllListeners();
    }

    public override void SetData(BuildingData data) {
        base.SetData(data);

        _buildingNameText.text = data.buildingName;
    }

    private void HandleSelectionButtonClick() {
        BuildingManager.Instance.SetSelectedBuildingData(Data);

        ProductionMenuController.Instance.RepositionAnimation.GetOutView();
    }

}
