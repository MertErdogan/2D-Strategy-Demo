using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingData {
    
    public BuildingData buildingData;
    public BuildingController building;
    public List<Vector3Int> occupiedGrids;

    public PlacedBuildingData(BuildingData buildingData, BuildingController building, List<Vector3Int> occupiedGrid) {
        this.buildingData = buildingData;
        this.building = building;
        this.occupiedGrids = occupiedGrid;
    }

}
