using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantController : BuildingController {

    public override void BuildingSelected() {
        BuildingMenuController.Instance.SetBuildingMenuData(BuildingData);

        base.BuildingSelected();
    }

}
