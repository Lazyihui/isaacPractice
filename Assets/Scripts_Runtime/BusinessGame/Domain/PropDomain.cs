using System;
using UnityEngine;


public static class PropDomain {
    public static PropEntity Spawn(GameContext ctx, Vector2 pos) {
        bool has = ctx.assetsContext.TryGetEntity("Prop_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("PropEntity not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PropEntity prop = go.GetComponent<PropEntity>();
        prop.Ctor();
        prop.SetPos(pos);
        prop.id = ctx.gameEntity.propRecordID;
        ctx.gameEntity.propRecordID++;
        ctx.propRespository.Add(prop);
        return prop;

    }

    public static void BoolisTrigger(GameContext ctx, PropEntity prop) {
        if (prop.isEnter) {
            prop.SetCollider(true);
        }

        if (prop.isObstacle) {
            prop.SetCollider(false);
        }

    }
}