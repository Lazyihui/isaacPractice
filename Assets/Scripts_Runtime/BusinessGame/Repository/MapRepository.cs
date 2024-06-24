using System;
using System.Collections.Generic;


public class MapRespository {

    Dictionary<int, MapEntity> all;

    MapEntity[] temArray;

    public MapRespository() {
        all = new Dictionary<int, MapEntity>();
        temArray = new MapEntity[5];
    }

    public void Add(MapEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(MapEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out MapEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new MapEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out MapEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<MapEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}