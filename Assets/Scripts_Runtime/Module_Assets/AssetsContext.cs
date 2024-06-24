using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class AssetsContext {


    public Dictionary<string, GameObject> entities;


    public AsyncOperationHandle entityPtr;

    public Dictionary<string, GameObject> panels;

    public AsyncOperationHandle panelPtr;

    public Dictionary<int, MapGridElement> maps;

    public AsyncOperationHandle mapPtr;

    public AssetsContext() {
        entities = new Dictionary<string, GameObject>();
        panels = new Dictionary<string, GameObject>();
        maps = new Dictionary<int, MapGridElement>();

    }
    public bool TryGetEntity(string name, out GameObject entity) {
        return entities.TryGetValue(name, out entity);
    }

    public bool TryGetPanel(string name, out GameObject panel) {
        return panels.TryGetValue(name, out panel);
    }


    public GameObject MapGrid_Get(int stageID) {
        MapGridElement mapGrid;
        if (maps.TryGetValue(stageID, out mapGrid)) {
            return mapGrid.gameObject;
        } else {
            return null;
        }
    }
}