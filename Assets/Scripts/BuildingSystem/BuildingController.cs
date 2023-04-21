using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingController : MonoBehaviour, IPoolObject {

    private BuildingData _buildingData;
    public BuildingData BuildingData {
        get => _buildingData;
        private set {
            _buildingData = value;

            _model.transform.localScale = new Vector3(_buildingData.buildingDimensions.x, _buildingData.buildingDimensions.y, 1f);
            _modelContainer.localPosition = new Vector3(_buildingData.buildingDimensions.x / 2f, _buildingData.buildingDimensions.y / 2f, 0f);
            (_buildingText.transform as RectTransform).sizeDelta = new Vector2(_buildingData.buildingDimensions.x / 10f, _buildingData.buildingDimensions.y / 10f);
            _buildingText.text = _buildingData.buildingName;
            BuildingHealth = _buildingData.buildingHealth;
        }
    }

    private int _buildingHealth;
    public int BuildingHealth {
        get => _buildingHealth;
        private set {
            _buildingHealth = value;

            if (_buildingHealth <= 0) {
                // TODO: destroy building
            }
        }
    }

    [Header("BuildingController")]
    [SerializeField] private Transform _modelContainer;
    [SerializeField] private SpriteRenderer _model;
    [SerializeField] private TextMeshPro _buildingText;

    public virtual void SetUpBuilding(BuildingData buildingData) { 
        BuildingData = buildingData;
    }

    public virtual void TakeDamage(int damage) {
        BuildingHealth -= damage;
    }

    public void SetColor(Color color, float alpha) {
        _model.color = new Color(color.r, color.g, color.b, alpha);
    }

    public virtual void BuildingSelected() {
        GameStateManager.Instance.SetGameState(GameState.BuildingMenu);
    }

    public virtual void OnBuildingPlaced() {

    }

    #region PoolObject

    public void Activate() {
        Debug.Log("activated");
    }

    public void Deactivate() {
        Debug.Log("deactivated");
    }

    #endregion

}
