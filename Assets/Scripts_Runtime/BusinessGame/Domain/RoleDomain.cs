using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx,Vector2 pos,int typeID) {
        ctx.assetsContext.TryGetEntity("Role_Entity", out GameObject prefab);

        bool has = ctx.templateContext.roles.TryGetValue(typeID, out RoleTM tm);

        if (!has) {
            Debug.LogError("RoleTM not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity role = go.GetComponent<RoleEntity>();
        role.typeID = tm.typeID;

        role.SetPos(pos);
        role.Ctor();

        role.moveSpeed = tm.moveSpeed;
        role.interval = tm.interval;
        role.intervalTimer = tm.intervalTimer;
        role.isRole = tm.isRole;
        role.animatior.runtimeAnimatorController = tm.animator;
        // role.interval = 3;
        // role.intervalTimer = 3;

        role.id = ctx.gameEntity.roleRecordID;
        ctx.gameEntity.roleRecordID++;
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