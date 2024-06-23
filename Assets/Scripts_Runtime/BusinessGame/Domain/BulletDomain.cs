using System;
using UnityEngine;

public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Vector2 pos) {
        bool has = ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("BulletEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        BulletEntity bullet = go.GetComponent<BulletEntity>();
        bullet.Ctor();
        bullet.SetPos(pos);

        bullet.id = ctx.gameEntity.bulletRecordID;
        ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);
        return bullet;
    }
}