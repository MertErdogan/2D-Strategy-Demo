using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoldierCarouselItem : CarouselItem<SoldierData> {

    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private Button _selectionButton;

    private void Awake() {
        _selectionButton.onClick.AddListener(HandleSelectionButtonClick);
    }

    private void OnDestroy() {
        _selectionButton.onClick.RemoveAllListeners();
    }

    public override void SetData(SoldierData data) {
        base.SetData(data);

        _nameText.text = data.soldierName;
        _healthText.text = "Health: " + data.soldierHealth;
        _healthText.text = "Damage: " + data.soldierDamage;
    }

    private void HandleSelectionButtonClick() {
        SoldierManager.Instance.SpawnSoldier(Data);
    }

}
