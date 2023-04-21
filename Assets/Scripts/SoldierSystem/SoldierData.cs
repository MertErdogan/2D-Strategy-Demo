using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SoldierData", menuName = "SoldierData")]
public class SoldierData : ScriptableObject {

    public int id;
    public string soldierName;
    public string soldierDescription;
    public int soldierPrice;
    public Sprite soldierIcon;
    public int soldierHealth;
    public int soldierDamage;

}
