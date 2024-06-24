using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx) {
        bool has = ctx.assetsContext.TryGetEntity("Role_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("RoleEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity role = go.GetComponent<RoleEntity>();
        role.Ctor();
        role.interval = 3;
        role.intervalTimer = 3;

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
}