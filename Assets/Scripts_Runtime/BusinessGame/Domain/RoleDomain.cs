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
        role.SetSprite(tm.sprite);

        role.moveSpeed = tm.moveSpeed;
        role.interval = tm.interval;
        role.intervalTimer = tm.intervalTimer;
        role.isRole = tm.isRole;
        role.isEnemy_1 = tm.isEnemy_1;
        role.animatior.runtimeAnimatorController = tm.animator;
        // role.interval = 3;
        // role.intervalTimer = 3;

        role.id = ctx.gameEntity.roleRecordID++;
        ctx.roleRespository.Add(role);
        return role;

    }

    public static void Move(GameContext ctx, RoleEntity role, Vector2 dir, float dt) {
        role.Move(dir, dt);
    }

    public static void ToSpawnBullet(GameContext ctx, RoleEntity role, float dt) {

        role.intervalTimer -= dt;

        if (role.intervalTimer <= 0) {

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position);
                bullet.dir = 1;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position);
                bullet.dir = 0;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position);
                bullet.dir = 2;
                role.intervalTimer = role.interval;

            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                BulletEntity bullet = BulletDomain.Spawn(ctx, role.transform.position);
                bullet.dir = 3;
                role.intervalTimer = role.interval;

            }


        }

    }

    // enemy 和 player 的大范围的检测 检测到enmey 就会自动攻击
    public static void EnemyToAttack(GameContext ctx, RoleEntity enemy, float dt) {
        int len = ctx.roleRespository.TakeAll(out RoleEntity[] array);
     
        for (int i = 0; i < len; i++) {
            RoleEntity item = array[i];
            if (item.isRole) {
                continue;
            }
            float dis = Vector2.Distance(enemy.transform.position, item.transform.position);

            if (dis < 2) {
        
                enemy.intervalTimer -= dt;
                if (enemy.intervalTimer <= 0) {
                    
                    BulletEntity bullet = BulletDomain.Spawn(ctx, enemy.transform.position);

                    enemy.intervalTimer = enemy.interval;
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