using System;
using System.Collections.Generic;
using UnityEngine;


public static class Game_Business {
    public static void New_Game(GameContext ctx) {

        ctx.gameEntity.Init();
        ctx.gameEntity.NoUpdata();

        RoleDomain.Spawn(ctx, new Vector2(0, 0));

        // map
        MapDomain.Spawn(ctx, 1);

        PropDomain.ToSpawnIsTriggerProp(ctx);

        PropEntity tem = PropDomain.Spawn(ctx, new Vector2(-3, 1), 1);
        // tem.isObstacle = true;
        // 后面用TM写


        // 打开panel
        UIApp.Panel_Heart_Open(ctx.uiContext, 3);

        UIApp.Panel_Figure_Open(ctx.uiContext);

        // Panel
        for (int i = 0; i < ctx.gameEntity.figureCount; i++) {
            UIApp.Panel_FigureElement_Add(ctx.uiContext, i);
        }


    }

    public static void Next_Level(GameContext ctx) {
        Vector2 pos = Vector2.zero;
        if (ctx.gameEntity.nextLevelID == 1) {
            pos = new Vector2(0, -5.5f);
        } else if (ctx.gameEntity.nextLevelID == 2) {
            pos = new Vector2(-1, 7.5f);
        } else if (ctx.gameEntity.nextLevelID == 3) {
            pos = new Vector2(11.5f, 0.5f);
        } else if (ctx.gameEntity.nextLevelID == 4) {
            pos = new Vector2(-11.5f, 1);
        }
        RoleDomain.Spawn(ctx, pos);
        ctx.gameEntity.Init();
        MapDomain.Spawn(ctx, 2);

        PropDomain.Spawn(ctx, new Vector2(-3, 1), PropConst.CHEST);
        PropDomain.ToSpawnIsTriggerProp(ctx);

    }

    public static void Load_Game(GameContext ctx) {

    }
    public static void UnLoad_Game(GameContext ctx) {

    }

    public static void Tick(GameContext ctx, float dt) {

        PreTick(ctx, dt);


        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.02f;

        if (restFixTime <= FIX_INTERVAL) {
            LogicFix(ctx, FIX_INTERVAL);
            restFixTime = 0;
        } else {
            while (restFixTime >= FIX_INTERVAL) {
                LogicFix(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }



        LateTick(ctx, dt);
    }


    static void PreTick(GameContext ctx, float dt) {
        ctx.moduleInput.ProcessMove();
    }

    static void LogicFix(GameContext ctx, float dt) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ctx.gameEntity.hp += 1;
        }

        // role 
        int roleLen = ctx.roleRespository.TakeAll(out RoleEntity[] roles);
        for (int i = 0; i < roleLen; i++) {
            RoleEntity role = roles[i];
            RoleDomain.Move(ctx, role, ctx.moduleInput.moveAxis, dt);
            RoleFSMConteoller.Tick(ctx, role, dt);

            RoleDomain.ToSpawnBullet(ctx, role, dt);
        }


        // bullet
        int bulletLen = ctx.bulletRespository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {

            BulletEntity bullet = bullets[i];

            BulletDomain.Move(ctx, bullet, dt);

            BulletDomain.BeyondBoundaryToUnSpawn(ctx, bullet);

            BulletDomain.MoveDistanceToUnSpawn(ctx, bullet, dt);
        }






        int propLen = ctx.propRespository.TakeAll(out PropEntity[] props);
        for (int i = 0; i < propLen; i++) {
            PropEntity prop = props[i];
            PropDomain.BoolisTrigger(ctx, prop);
            PropDomain.EnterNextLevel(ctx, prop);
            // 问题
            // PropDomain.SetRigidbody(ctx, prop);
        }



        // 清除全部

        if (ctx.gameEntity.isEnterLevel) {
            RoleDomain.CloseAll(ctx);
            BulletDomain.CloseAll(ctx);
            PropDomain.CloseAll(ctx);
            MapDomain.CloseAll(ctx);
            Next_Level(ctx);
        }


    }

    static void LateTick(GameContext ctx, float dt) {
        UIApp.Panel_Heart_Unpdate(ctx.uiContext, ctx.gameEntity.hp);

        //  panel giureElement
        int figureEleLen = ctx.uiContext.figureEleRespository.TakeAll(out Panel_FigureElement[] figureEles);

        for (int i = 0; i < figureEleLen; i++) {
            Panel_FigureElement ele = figureEles[i];
            if (ele.typeID == PropConst.GOLD) {
                UIApp.Panel_FigureElement_SetText(ctx.uiContext, ele, ele.typeID, ctx.gameEntity.goldCount);
            }
            if (ele.typeID == PropConst.BOMB) {
                UIApp.Panel_FigureElement_SetText(ctx.uiContext, ele, ele.typeID, ctx.gameEntity.bombCount);
            }
            if (ele.typeID == PropConst.KEY) {
                UIApp.Panel_FigureElement_SetText(ctx.uiContext, ele, ele.typeID, ctx.gameEntity.keyCount);
            }
        }
    }
}
