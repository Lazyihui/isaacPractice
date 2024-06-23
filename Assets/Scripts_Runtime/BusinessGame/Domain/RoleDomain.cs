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

        role.Ctor();
        role.id = ctx.gameEntity.roleRecordID++;
        ctx.roleRespository.Add(role);
        return role;

    }
}