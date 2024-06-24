using System;
using UnityEngine;

public static class MapDomain {
    public static MapEntity Spawn(GameContext ctx, int stageID) {
        // 1.得到 Entity
        bool has = ctx.assetsContext.TryGetEntity("Map_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("MapEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        MapEntity map = go.GetComponent<MapEntity>();
        map.Ctor();
        map.id = stageID;
        ctx.mapRespository.Add(map);

        // 2.得到地图数据 MapGridElement
        GameObject gridPrefab = ctx.assetsContext.MapGrid_Get(stageID);
        MapGridElement grid = GameObject.Instantiate(gridPrefab).GetComponent<MapGridElement>();

        map.Inject(grid);
        return map;

    }

    public static void TearDown(GameContext ctx, MapEntity map) {
        ctx.mapRespository.Remove(map);
        map.TearDown();
    }


    

}