using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {
        ctx.assetsContext.TryGetEntity("Role_Entity", out GameObject prefab);

        bool has = ctx.templateContext.roles.TryGetValue(typeID, out RoleTM tm);

        if (!has) {
            Debug.LogError("RoleTM not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity role = go.GetComponent<RoleEntity>();
        role.typeID = typeID;

        role.Ctor();
        role.SetPos(pos);
        role.SetSprite(tm.sprite, tm.color);

        role.moveSpeed = tm.moveSpeed;
        role.interval = tm.interval;
        role.intervalTimer = tm.intervalTimer;
        role.isRole = tm.isRole;
        role.animatior.runtimeAnimatorController = tm.animator;

        role.isEnemy_1 = tm.isEnemy_1;
        role.enmeny_1_Hp = tm.enmeny_1_Hp;



        role.id = ctx.gameEntity.roleRecordID++;
        ctx.roleRespository.Add(role);
        return role;

    }
    // player 死亡的函数//相当于游戏结束
    public static void Player_Die(GameContext ctx, RoleEntity role) {
        // 外面这个判断好像是多余的
        if (role.isRole) {
            if (ctx.gameEntity.hp <= 0) {
                UnSpawn(ctx, role);
            }
        }
    }

    // enemy 的死亡
    public static void Enemy_1_Die(GameContext ctx, RoleEntity enemy) { 
        // 外面这个判断好像是多余的
        if (enemy.isEnemy_1) {
            if (enemy.enmeny_1_Hp <= 0) {
                UnSpawn(ctx, enemy);
                ctx.gameEntity.currentEnemyCount--;
            }
        }
    }

    public static void Move(GameContext ctx, RoleEntity role, Vector2 dir, float dt) {
        role.Move(dir, dt);
    }

    public static void ToSpawnBullet(GameContext ctx, RoleEntity role, float dt) {

        role.intervalTimer -= dt;

        if (role.intervalTimer <= 0) {

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position, 0);
                bullet.dir_player = 1;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position, 0);
                bullet.dir_player = 0;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position, 0);
                bullet.dir_player = 2;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position, 0);
                bullet.dir_player = 3;
                role.intervalTimer = role.interval;

            }


        }

    }

    // enemy 和 player 的大范围的检测 检测到enmey 就会自动攻击
    public static void EnemyToAttack(GameContext ctx, RoleEntity player, float dt) {
        int len = ctx.roleRespository.TakeAll(out RoleEntity[] array);

        for (int i = 0; i < len; i++) {
            RoleEntity enemey = array[i];
            if (enemey.isRole) {
            } else {
                continue;
            }


            float dis = Vector2.SqrMagnitude(player.transform.position - enemey.transform.position);
            if (Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(player.id + "距离" + dis);
            }

            if (dis < 60) {
                player.intervalTimer -= dt;
                if (player.intervalTimer <= 0) {
                    BulletEntity bullet = BulletDomain.Spawn(ctx, player.transform.position, 1);
                    bullet.dir_Enmeny1 = enemey.transform.position - player.transform.position;

                    player.intervalTimer = player.interval;
                }


            }
        }


    }

    public static void UnSpawn(GameContext ctx, RoleEntity role) {
        ctx.roleRespository.Remove(role);
        role.TearDown();
    }
    public static void CloseAll(GameContext ctx) {
        int len = ctx.roleRespository.TakeAll(out RoleEntity[] array);
        for (int i = 0; i < len; i++) {
            UnSpawn(ctx, array[i]);
        }
    }

}