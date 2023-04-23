using DG.Tweening;
using System;
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

            _healthBar.UpdateHealthBar((float)_health / SoldierData.soldierHealth);

            if (_health <= 0) {
                SoldierManager.Instance.RecycleSoldier(this);
            }
        }
    }

    [SerializeField] private TextMeshPro _nameText;
    [SerializeField] private HealthBarController _healthBar;

    private int _pathIndex = 0;
    private List<WorldTile> _path;

    public void SetSoldierData(SoldierData soldierData) { 
        SoldierData = soldierData;
    }

    public void SelectSoldier() {
        SoldierInteractionManager.Instance.SetSelectedSoldier(this);

        GameStateManager.Instance.SetGameState(GameState.SoldierMenu);

        SoldierViewController.Instance.SetSoldierView(SoldierData.soldierName, Health, SoldierData.soldierDamage);
    }

    public void TakeDamage(int damage) {
        Health -= damage;
    }

    #region Attack

    public void Attack(SoldierController soldier) {
        MoveToTarget(soldier.transform.position, () => {
            soldier.TakeDamage(SoldierData.soldierDamage);
        });
    }

    public void Attack(BuildingController building) {
        MoveToTarget(building.GetClosestPoint(transform.position), () => {
            building.TakeDamage(SoldierData.soldierDamage);
        });
    }

    #endregion

    #region Movement

    public void MoveToTarget(Vector3 targetPosition, Action OnTargetReached = null) {
        PathFindController.Instance.FindPath(transform.position, targetPosition, (path) => {
            _path = path;

            MovePath(OnTargetReached);
        });
    }

    private void MovePath(Action OnTargetReached) {
        if (_path.Count <= 0) {
            OnTargetReached?.Invoke();

            return;
        }

        MoveTile(_path[_pathIndex], OnTargetReached);
    }

    private void MoveTile(WorldTile tile, Action OnTargetReached) {
        transform.DOKill();
        transform.DOMove(tile.TileWorldPosition, 0.5f).SetEase(Ease.Linear).OnComplete(() => {
            if ((_pathIndex + 1) >= _path.Count) {
                _path = new List<WorldTile>();
                _pathIndex = 0;

                OnTargetReached?.Invoke();

                return;
            }

            MoveTile(_path[++_pathIndex], OnTargetReached);
        });
    }

    #endregion

    #region IPool

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }

    #endregion

}
