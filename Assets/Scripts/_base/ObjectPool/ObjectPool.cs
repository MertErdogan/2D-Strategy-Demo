using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : IPoolObject {

    [Header("ObjectPool")]
    [SerializeField] private GameObject _poolObjectPrefab;

    private List<T> _pool;

    private void Awake() {
        _pool = new List<T>();
    }

    public T GetObjectFromPool() {
        if (_pool.Count <= 0)
            AddObjectToPool();

        int index = _pool.Count - 1;
        T poolObject = _pool[index];
        _pool.RemoveAt(index);

        return poolObject;
    }

    public void AddObjectToPool(T poolObject) {
        _pool.Add(poolObject);
    }

    public void AddObjectToPool() {
        T poolObject = Instantiate(_poolObjectPrefab).GetComponent<T>();

        AddObjectToPool(poolObject);
    }

}
