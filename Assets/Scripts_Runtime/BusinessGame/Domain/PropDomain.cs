using System;
using UnityEngine;
using UnityEngine.UI;



public static class PropDomain {
    public static PropEntity Spawn(GameContext ctx, Vector2 pos, int typeID, int nextLevelID) {
        ctx.assetsContext.TryGetEntity("Prop_Entity", out GameObject prefab);

        bool has = ctx.templateContext.props.TryGetValue(typeID, out PropTM tm);
        if (!has) {
            Debug.LogError("PropTM not found");
            return null;
        }
        GameObject go = GameObject.Instantiate(prefab);
        PropEntity prop = go.GetComponent<PropEntity>();
        prop.Ctor();
        prop.SetPos(pos);
        prop.typeID = typeID;
        prop.nextLevelID = 0;
        prop.SetSprite(tm.sprite);

        prop.isEnter = tm.isEnter;
        prop.isObstacle = tm.isObstacle;
        prop.isFigure = tm.isFigure;

        prop.isGold = tm.isGold;
        prop.isbomb = tm.bomb;
        prop.isKey = tm.isKey;

        prop.isChest = tm.isChest;
        prop.isLive = tm.isLive;

        prop.isCoin = tm.isCoin;

        prop.animatior.runtimeAnimatorController = tm.animator;
        prop.id = ctx.gameEntity.propRecordID;
        prop.nextLevelID = nextLevelID;
        ctx.gameEntity.propRecordID++;
        ctx.propRespository.Add(prop);
        return prop;

    }
    public static void UnSpawn(GameContext ctx, PropEntity prop) {
        ctx.propRespository.Remove(prop);
        prop.TearDown();
    }

    public static void BoolisTrigger(GameContext ctx, PropEntity prop) {
        if (prop.isEnter) {
            prop.SetCollider(true);
        } else {
            prop.SetCollider(false);
        }



    }

    public static void ToSpawnIsTriggerProp(GameContext ctx) {
        PropEntity prop = Spawn(ctx, new Vector2(-13, 1), 0, 3);
        PropEntity prop1 = Spawn(ctx, new Vector2(-1f, 8.5f), 0, 1);
        PropEntity prop2 = Spawn(ctx, new Vector2(13, 1), 0, 4);
        PropEntity prop3 = Spawn(ctx, new Vector2(0, -7), 0, 2);
        PropEntity prop4 = Spawn(ctx, new Vector2(13, -0.5f), 0, 4);
        PropEntity prop5 = Spawn(ctx, new Vector2(-13, -0.5f), 0, 3);
    }

    public static void SetRigidbody(GameContext ctx, PropEntity prop) {
        if (prop.typeID == PropConst.CHEST) {
            prop.SetRigidbody(RigidbodyType2D.Dynamic);
        } else {
            prop.SetRigidbody(RigidbodyType2D.Static);
        }


    }


    static void OnTriggerEnter(PropEntity prop, Collider2D other) {
        Debug.Log("Enter");
        if (other.gameObject.CompareTag("Role")) {
            Debug.Log("Role Enter");
        }

    }
    public static void EnterNextLevel(GameContext ctx, PropEntity prop) {
        int roleLen = ctx.roleRespository.TakeAll(out RoleEntity[] roles);
        if (prop.isObstacle) {
            return;
        }

        for (int i = 0; i < roleLen; i++) {
            RoleEntity role = roles[i];
            float dirSqr = Vector2.SqrMagnitude(role.transform.position - prop.transform.position);
            if (dirSqr < 0.5f) {
                ctx.gameEntity.isEnterLevel = true;
                switch (prop.nextLevelID) {
                    case 1:
                        ctx.gameEntity.nextLevelID = 1;
                        break;
                    case 2:
                        ctx.gameEntity.nextLevelID = 2;
                        break;
                    case 3:
                        ctx.gameEntity.nextLevelID = 3;
                        break;
                    case 4:
                        ctx.gameEntity.nextLevelID = 4;
                        break;
                    default:
                        break;
                }
            }


        }

    }

    // 碰到宝箱生成金币
    public static void ChestSpawnGold(GameContext ctx, PropEntity prop) {

        int len = ctx.roleRespository.TakeAll(out RoleEntity[] roles);

        for (int i = 0; i < len; i++) {

            RoleEntity role = roles[i];
            float dirSqr = Vector2.SqrMagnitude(role.transform.position - prop.transform.position);

            if (prop.typeID == PropConst.CHEST && prop.isLive) {
                if (dirSqr < 1.0f) {
                    Vector2 pos = prop.transform.position;
                    PropDomain.Spawn(ctx, new Vector2(pos.x - 3, pos.y - 4), PropConst.COIN, 0);
                    PropDomain.Spawn(ctx, new Vector2(pos.x + 2, pos.y + 1), PropConst.COIN, 0);
                    PropDomain.Spawn(ctx, new Vector2(pos.x - 2, pos.y + 3), PropConst.COIN, 0);
                    prop.isLive = false;

                }
            }

            if (prop.typeID == PropConst.COIN) {
                if (dirSqr < 1.0f) {
                    ctx.gameEntity.goldCount += 1;
                    UnSpawn(ctx, prop);
                }

            }


        }

    }


    public static void CloseAll(GameContext ctx) {
        int len = ctx.propRespository.TakeAll(out PropEntity[] props);
        for (int i = 0; i < len; i++) {
            UnSpawn(ctx, props[i]);
        }
    }
}