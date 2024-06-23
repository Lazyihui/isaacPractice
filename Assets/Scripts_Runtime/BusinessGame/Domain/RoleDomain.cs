using System;
using UnityEngine;


public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx) {
        bool has = ctx.assetsContext.TryGetEntity("RoleEntity", out GameObject prefab);

        if (!has) {
            Debug.LogError("RoleEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity role = go.GetComponent<RoleEntity>();
        role.isRole = false;
        role.Ctor();
        role.id = ctx.gameEntity.roleRecordID;
        ctx.gameEntity.roleRecordID++;
        ctx.roleRespository.Add(role);
        return role;

    }

    public static void Move(GameContext ctx,RoleEntity role, Vector2 dir,float dt) {
        role.Move(dir,dt);
    }
}