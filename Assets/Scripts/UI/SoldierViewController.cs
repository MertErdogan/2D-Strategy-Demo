using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierViewController : SingleInstance<SoldierViewController> {

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;

    public void SetSoldierView(string name, int health, int damage) {
        _nameText.text = name;
        _healthText.text = "Health: " + health;
        _damageText.text = "Damage: " + damage;
    }

}
