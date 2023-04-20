using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingData", menuName = "BuildingData")]
public class BuildingData : ScriptableObject {

    public int id;
    public string buildingName;
    public string buildingDescription;
    public int buildingPrice;
    public Sprite buildingIcon;
    public Vector2Int buildingDimensions;
    public int buildingHealth;
    public BuildingController building;

}
