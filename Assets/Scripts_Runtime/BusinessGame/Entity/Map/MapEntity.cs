using System;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapEntity : MonoBehaviour {

    public int id;

    MapGridElement grid;

    public void Ctor() {
    }

    public void Inject(MapGridElement grid) {
        this.grid = grid;
    }

}
