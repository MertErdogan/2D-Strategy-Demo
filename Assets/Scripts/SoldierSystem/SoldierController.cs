using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierController : MonoBehaviour, IPoolObject {

    private SoldierData _soldierData;
    public SoldierData SoldierData {
        get => _soldierData;
        private set {
            _soldierData = value;

            _nameText.text = _soldierData.soldierName;
            Health = _soldierData.soldierHealth;
        }
    }

    private int _health;
    public int Health {
        get => _health;
        private set {
            _health = value;

            if (_health <= 0) {
                SoldierManager.Instance.RecycleSoldier(this);
            }
        }
    }

    [SerializeField] private TextMeshPro _nameText;

    public void SetSoldierData(SoldierData soldierData) { 
        SoldierData = soldierData;
    }

    public void SelectSoldier() {
        SoldierInteractionManager.Instance.SetSelectedSoldier(this);

        GameStateManager.Instance.SetGameState(GameState.SoldierMenu);

        SoldierViewController.Instance.SetSoldierView(SoldierData.soldierName, Health, SoldierData.soldierDamage);
    }

    public void Attack(SoldierController soldier) {
        MoveToTarget(soldier.transform);

        // TODO: attack soldier
        Debug.Log("attacking soldier");
    }

    public void Attack(BuildingController building) {
        MoveToTarget(building.transform);

        // TODO: attack building
        Debug.Log("attacking building");
    }

    private void MoveToTarget(Transform targetTransform) {
        // TODO: move navmesh
    }

    #region IPool

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    #endregion

}
