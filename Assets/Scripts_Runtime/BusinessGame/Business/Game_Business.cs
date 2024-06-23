using System;
using System.Collections.Generic;
using UnityEngine;


public static class Game_Business {
    public static void New_Game(GameContext ctx) {

        RoleDomain.Spawn(ctx);
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
        // role 

        int roleLen = ctx.roleRespository.TakeAll(out RoleEntity[] roles);
        for (int i = 0; i < roleLen; i++) {
            RoleEntity role = roles[i];
            RoleDomain.Move(ctx, role, ctx.moduleInput.moveAxis,dt);
        }


    }

    static void LateTick(GameContext ctx, float dt) { }
}
