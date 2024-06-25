using System;
using UnityEngine;
using UnityEngine.UI;



public static class PropDomain {
    public static PropEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {
        bool has = ctx.assetsContext.TryGetEntity("Prop_Entity", out GameObject prefab);

        if (!has) {
            Debug.LogError("PropEntity not found");
            return null;
        }

        

        GameObject go = GameObject.Instantiate(prefab);
        PropEntity prop = go.GetComponent<PropEntity>();
        prop.Ctor();
        prop.SetPos(pos);
        prop.typeID = typeID;
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

    public static void ToSpawnIsTriggerProp(GameContext ctx) {
        PropEntity prop = Spawn(ctx, new Vector2(-13, 1), 0);
        prop.isEnter = true;
        PropEntity prop1 = Spawn(ctx, new Vector2(-1f, 8.5f), 0);
        prop1.isEnter = true;
        PropEntity prop2 = Spawn(ctx, new Vector2(13, 1), 0);
        prop2.isEnter = true;
        PropEntity prop3 = Spawn(ctx, new Vector2(0, -7), 0);
        prop3.isEnter = true;
        PropEntity prop4 = Spawn(ctx, new Vector2(13, -0.5f), 0);
        prop4.isEnter = true;
        PropEntity prop5 = Spawn(ctx, new Vector2(-13, -0.5f), 0);
        prop5.isEnter = true;
    }

    public static void SetSprite(GameContext ctx, PropEntity prop) {
        bool has = ctx.templateContext.props.TryGetValue(prop.typeID, out PropTM tm);
        if (!has) {
            Debug.LogError("PropTM not found");
            return;
        }
        prop.SetSprite(tm.sprite);
        prop.isEnter = tm.isEnter;
        prop.isObstacle = tm.isObstacle;
    }
}