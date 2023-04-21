using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuController : SingleInstance<BuildingMenuController> {

    private BuildingData _buildingData;
    public BuildingData BuildingData {
        get => _buildingData;
        private set {
            _buildingData = value;

            _buildingNameText.text = _buildingData.buildingName;
        }
    }

    [SerializeField] private TextMeshProUGUI _buildingNameText;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private GameObject _scrollRect;

    public void SetBuildingMenuData(BuildingData buildingData, bool hasProduction = false) { 
        BuildingData = buildingData;

        _scrollRect.SetActive(hasProduction);
    }

}
