using System;
using UnityEngine;

public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {
        ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);

        bool has = ctx.templateContext.bullets.TryGetValue(typeID, out BulletTM tm);

        GameObject go = GameObject.Instantiate(prefab);
        BulletEntity bullet = go.GetComponent<BulletEntity>();
        bullet.Ctor();
        bullet.SetPos(pos);
        bullet.SetSprite(tm.sprite);
        bullet.SetRB(RigidbodyType2D.Kinematic);
        bullet.dir_player = 0;
        bullet.moveDistance = tm.moveDistance;
        bullet.maxDistance = tm.maxDistance;

        bullet.intervalTimer = tm.intervalTimer;

        bullet.moveSpeed = tm.moveSpeed;

        bullet.isRoleBullet = tm.isRoleBullet;
        bullet.isEnemyBullet = tm.isEnemyBullet;

        bullet.id = ctx.gameEntity.bulletRecordID;
        ctx.gameEntity.bulletRecordID++;
        ctx.bulletRespository.Add(bullet);
        return bullet;
    }
    // enemny_1 bullet  的函数
    public static void Enemy1_BulletTouchPlayer(GameContext ctx, BulletEntity bullet) {
        RoleEntity player = ctx.roleRespository.Find(x => x.isRole);
        if (player == null) {
            return;
        }
        Vector2 playerPos = player.transform.position;
        Vector2 bulletPos = bullet.transform.position;
        float distance = Vector2.SqrMagnitude(playerPos - bulletPos);
        if (distance < 0.5f) {
            ctx.gameEntity.hp -= 1;
            BulletDomain.UnSpawn(ctx, bullet);
        }

    }
    // player bullet 的函数
    public static void player_BulletTouchEnemy(GameContext ctx, BulletEntity bullet) {
        RoleEntity enemy = ctx.roleRespository.Find(x => x.typeID == RoleConst.ENEMY_1|| x.typeID == RoleConst.ENEMY_2|| x.typeID == RoleConst.ENEMY_3);
        if (enemy == null) {
            return;
        }

        

        Vector2 enemyPos = enemy.transform.position;
        Vector2 bulletPos = bullet.transform.position;
        float distance = Vector2.SqrMagnitude(enemyPos - bulletPos);
        if (distance < 0.5f) {
            enemy.enmeny_1_Hp -= 1;
            BulletDomain.UnSpawn(ctx, bullet);
        }

    }

    public static void Move(GameContext ctx, BulletEntity bullet, float dt) {

        if (bullet.dir_player == 0) {
            bullet.Move(Vector2.down, dt);
        }

        if (bullet.dir_player == 1) {
            bullet.Move(Vector2.up, dt);
        }

        if (bullet.dir_player == 2) {
            bullet.Move(Vector2.left, dt);
        }

        if (bullet.dir_player == 3) {
            bullet.Move(Vector2.right, dt);
        }

    }

    // enemy_1 bullet 的移动 
    public static void Enemy_1_Move(GameContext ctx, BulletEntity bullet, RoleEntity player, float dt) {
        // 向player移动
        Vector2 dir = bullet.dir_Enmeny1;
        dir.Normalize();
        bullet.Move(dir, dt);

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