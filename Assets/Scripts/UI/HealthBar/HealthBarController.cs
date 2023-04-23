using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    [SerializeField] private Image _fillImage;

    public void UpdateHealthBar(float fillAmmount) {
        if (fillAmmount == 1) {
            _fillImage.fillAmount = fillAmmount;

            return;
        }

        _fillImage.DOKill();
        _fillImage.DOFillAmount(fillAmmount, 0.25f);
    }

}
