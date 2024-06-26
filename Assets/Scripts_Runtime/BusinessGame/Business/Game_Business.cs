using System;
using System.Collections.Generic;
using UnityEngine;


public static class Game_Business {
    public static void New_Game(GameContext ctx) {

        RoleDomain.Spawn(ctx);

        // map
        MapDomain.Spawn(ctx, 1);

        PropDomain.ToSpawnIsTriggerProp(ctx);

        PropEntity tem = PropDomain.Spawn(ctx, new Vector2(-3, 1), 1);
        tem.isObstacle = true;
        // 后面用TM写


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
            Debug.Log(ctx.gameEntity.nextLevelID);
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
            PropDomain.SetSprite(ctx, prop);
            PropDomain.EnterNextLevel(ctx, prop);
        }

        // 清除全部

        if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("CloseAll");
            RoleDomain.CloseAll(ctx);
            BulletDomain.CloseAll(ctx);
            PropDomain.CloseAll(ctx);
            MapDomain.CloseAll(ctx);
        }


    }

    static void LateTick(GameContext ctx, float dt) { }
}
