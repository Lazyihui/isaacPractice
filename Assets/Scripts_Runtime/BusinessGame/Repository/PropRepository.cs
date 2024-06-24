using System;
using System.Collections.Generic;


public class PropRespository {

    Dictionary<int, PropEntity> all;

    PropEntity[] temArray;

    public PropRespository() {
        all = new Dictionary<int, PropEntity>();
        temArray = new PropEntity[5];
    }

    public void Add(PropEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(PropEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out PropEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new PropEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out PropEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<PropEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}