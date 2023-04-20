using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Carousel<CarouselType, DataType> : MonoBehaviour where CarouselType : CarouselItem<DataType>
{
    public CarouselType CarouselPrefab;
    public Transform CarouselContainer;

    protected List<CarouselType> carouselItems = new List<CarouselType>();


    public void CreateItems(List<DataType> dataList) {
        CreateItems(dataList.ToArray());
    }

    public virtual void CreateItems(DataType[] dataList) {
        Clear();

        carouselItems = new List<CarouselType>();
        foreach(DataType data in dataList) {

            CarouselType carousel = GameObject.Instantiate(CarouselPrefab, CarouselContainer);
            carouselItems.Add(carousel);
            carousel.SetData(data);
            OnItemCreated(carousel);
        }

        OnItemsCreated(carouselItems);
    }

    public bool SetData(DataType[] dataList) {
        if (carouselItems == null || dataList.Length != carouselItems.Count || carouselItems.Count == 0)
            return false;

        for (int i = 0; i < dataList.Length; i++)
            carouselItems[i].SetData(dataList[i]);
        return true;
    }

    protected virtual void OnItemCreated(CarouselType item) {

    }
    protected virtual void OnItemsCreated(List<CarouselType> items) {

    }

    public virtual void Clear() {
        while(carouselItems.Count > 0) {
            CarouselType item = carouselItems[0];
            carouselItems.RemoveAt(0);

            if (item.gameObject != null) {
#if UNITY_EDITOR
                GameObject.DestroyImmediate(item.gameObject);
#else
                GameObject.Destroy(item.gameObject);                                
#endif
            }


        }
    }
}
