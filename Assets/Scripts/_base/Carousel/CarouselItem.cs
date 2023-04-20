using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarouselItem<DataType> : MonoBehaviour
{
    private DataType data;
    public DataType Data {
        get { return data; }
        protected set {
            data = value;
        }
    }

    public virtual void SetData(DataType data) {
        Data = data;
    }
	
}
