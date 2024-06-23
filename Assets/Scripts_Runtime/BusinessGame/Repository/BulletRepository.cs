using System;
using System.Collections.Generic;


public class BulletRespository {

    Dictionary<int, BulletEntity> all;

    BulletEntity[] temArray;

    public BulletRespository() {
        all = new Dictionary<int, BulletEntity>();
        temArray = new BulletEntity[5];
    }

    public void Add(BulletEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(BulletEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out BulletEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new BulletEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out BulletEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<BulletEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}