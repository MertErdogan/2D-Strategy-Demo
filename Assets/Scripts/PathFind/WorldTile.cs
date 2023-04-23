using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour {

    [SerializeField] private bool _walkable;
    public bool Walkable {
        get => _walkable;
        set {
            _walkable = value;

            _iconImage.color = _walkable ? Color.white : Color.red;
        }
    }

    public Vector3 TileWorldPosition { get => new Vector3 (cellX, cellY, 0); }

    public int gCost;
    public int hCost;
    public int gridX, gridY, cellX, cellY;
    public List<WorldTile> myNeighbours;
    public WorldTile parent;
    [SerializeField] private SpriteRenderer _iconImage;

    public WorldTile(bool _walkable, int _gridX, int _gridY) {
        Walkable = _walkable;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost {
        get {
            return gCost + hCost;
        }
    }

}
