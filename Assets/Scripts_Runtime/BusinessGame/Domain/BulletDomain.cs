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
        bullet.dir = 0;

        bullet.id = ctx.gameEntity.bulletRecordID;
        ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);
        return bullet;
    }

    public static void Move(GameContext ctx, BulletEntity bullet, float dt) {

        if(bullet.dir == 0) {
            bullet.Move(Vector2.down, dt);
        }

        if(bullet.dir == 1) {
            bullet.Move(Vector2.up, dt);
        }

        if(bullet.dir == 2) {
            bullet.Move(Vector2.left, dt);
        }

        if(bullet.dir == 3) {
            bullet.Move(Vector2.right, dt);
        }

    }

    public static void UnSpawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRespository.Remove(bullet);
        bullet.TearDown();
    }
}