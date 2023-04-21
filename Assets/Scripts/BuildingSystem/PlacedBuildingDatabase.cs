using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingDatabase {
    
    public List<PlacedBuildingData> placedBuildings;

    public PlacedBuildingDatabase() {
        placedBuildings = new List<PlacedBuildingData>();
    }

    public PlacedBuildingDatabase(List<PlacedBuildingData> placedBuildings) {
        this.placedBuildings = placedBuildings;
    }

    public void AddPlacedBuilding(PlacedBuildingData placedBuilding) {
        if (placedBuildings.Contains(placedBuilding)) return;

        placedBuildings.Add(placedBuilding);
    }

    public void RemovePlacedBuilding(PlacedBuildingData placedBuilding) {
        if (placedBuildings == null || placedBuildings.Count <= 0) return;

        if (!placedBuildings.Contains(placedBuilding)) return;

        placedBuildings.Remove(placedBuilding);
    }

    public void RemovePlacedBuilding(BuildingController building) {
        if (placedBuildings == null || placedBuildings.Count <= 0) return;

        PlacedBuildingData placedBuilding = placedBuildings.Find(b => b.building == building);
        if (placedBuilding == null) return;

        RemovePlacedBuilding(placedBuilding);
    }

}
