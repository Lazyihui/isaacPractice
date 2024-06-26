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
        bullet.SetRB(RigidbodyType2D.Kinematic);
        bullet.dir = 0;
        bullet.moveDistance = 0;
        bullet.maxDistance = 7;

        bullet.intervalTimer = 5;

        bullet.id = ctx.gameEntity.bulletRecordID;
        ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);
        return bullet;
    }

    public static void Move(GameContext ctx, BulletEntity bullet, float dt) {

        if (bullet.dir == 0) {
            bullet.Move(Vector2.down, dt);
        }

        if (bullet.dir == 1) {
            bullet.Move(Vector2.up, dt);
        }

        if (bullet.dir == 2) {
            bullet.Move(Vector2.left, dt);
        }

        if (bullet.dir == 3) {
            bullet.Move(Vector2.right, dt);
        }

    }

    public static void UnSpawn(GameContext ctx, BulletEntity bullet) {
        ctx.bulletRespository.Remove(bullet);
        bullet.TearDown();
    }

    public static void BeyondBoundaryToUnSpawn(GameContext ctx, BulletEntity bullet) {
        Vector2 pos = bullet.transform.position;
        if (pos.x < -13 || pos.x > 13) {
            UnSpawn(ctx, bullet);
        }
        if (pos.y > 8.5 || pos.y < -6) {
            UnSpawn(ctx, bullet);
        }
    }


    public static void MoveDistanceToUnSpawn(GameContext ctx, BulletEntity bullet, float dt) {

        bullet.moveDistance += bullet.moveSpeed * dt;
        if (bullet.moveDistance >= bullet.maxDistance) {


            bullet.SetRB(RigidbodyType2D.Dynamic);

            bullet.intervalTimer -= dt;
            if (bullet.intervalTimer <= 0) {
                UnSpawn(ctx, bullet);
            }

        }

    }

    public static void CloseAll(GameContext ctx) {
        int len = ctx.bulletRespository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < len; i++) {
            UnSpawn(ctx, bullets[i]);
        }
    }


}