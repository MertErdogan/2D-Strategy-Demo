using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour, IPoolObject {

    private SoldierData _soldierData;
    public SoldierData SoldierData {
        get => _soldierData;
        private set {
            _soldierData = value;
        }
    }

    public void SetSoldierData(SoldierData soldierData) { 
        SoldierData = soldierData;
    }

    #region IPool

    public void Activate() {
        throw new System.NotImplementedException();
    }

    public void Deactivate() {
        throw new System.NotImplementedException();
    }

    #endregion

}
