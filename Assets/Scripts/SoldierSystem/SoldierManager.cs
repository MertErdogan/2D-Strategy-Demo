using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : SingleInstance<SoldierManager> {

    [SerializeField] private SoldierPool _pool;
    [SerializeField] private SoldierCarousel _carousel;

    public void CreateSoldierCarouselItems(List<SoldierData> soldiers) {
        _carousel.Clear();

        _carousel.CreateItems(soldiers);
    }

}
