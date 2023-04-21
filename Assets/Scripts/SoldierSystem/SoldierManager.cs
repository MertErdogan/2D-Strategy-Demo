using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : SingleInstance<SoldierManager> {

    [SerializeField] private SoldierPool _pool;
    [SerializeField] private SoldierCarousel _carousel;

    private Vector3Int _spawnPoint;

    public void CreateSoldierCarouselItems(List<SoldierData> soldiers, Vector3Int spawnPoint) {
        _spawnPoint = spawnPoint;

        _carousel.Clear();

        _carousel.CreateItems(soldiers);
    }

    public void SpawnSoldier(SoldierData data) {
        SoldierController soldier = _pool.GetObjectFromPool();
        soldier.SetSoldierData(data);
        soldier.transform.position = _spawnPoint;

        soldier.Activate();
    }

    public void RecycleSoldier(SoldierController soldier) {
        soldier.Deactivate();

        _pool.AddObjectToPool(soldier);
    }

}
