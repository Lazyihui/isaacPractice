using System;
using System.Collections.Generic;
using UnityEngine;


public static class Game_Business {
    public static void New_Game(GameContext ctx) {
        
        Debug.Log("Game_Business Init");
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

    static void LogicFix(GameContext ctx, float dt) { }

    static void LateTick(GameContext ctx, float dt) { }
}
