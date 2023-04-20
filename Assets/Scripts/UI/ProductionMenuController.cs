using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionMenuController : SingleInstance<ProductionMenuController> {

    public RepositionAnimation RepositionAnimation { get => _repositionAnimation; }

    [SerializeField] private RepositionAnimation _repositionAnimation;

}
