using System;
using System.Collections.Generic;
using UnityEngine;


public static class Game_Business {
    public static void New_Game(GameContext ctx) {

        ctx.gameEntity.Init();
        ctx.gameEntity.NoUpdata();

        RoleDomain.Spawn(ctx, new Vector2(0, 0), RoleConst.PLAYER);

        // map
        MapDomain.Spawn(ctx, 1);

        PropDomain.ToSpawnIsTriggerProp(ctx);

        PropDomain.Spawn(ctx, new Vector2(-3, 1), 1, 0);


        // 打开panel
        UIApp.Panel_Heart_Open(ctx.uiContext, 3);

        UIApp.Panel_Figure_Open(ctx.uiContext);

        // Panel
        for (int i = 0; i < ctx.gameEntity.figureCount; i++) {
            UIApp.Panel_FigureElement_Add(ctx.uiContext, i);
        }


    }

    public static void Next_Level(GameContext ctx) {
        // 3 4 的关卡
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
        ctx.gameEntity.Init();
        RoleDomain.Spawn(ctx, pos, RoleConst.PLAYER);
        MapDomain.Spawn(ctx, 2);
        PropDomain.Spawn(ctx, new Vector2(3, 1), PropConst.CHEST, 0);

        PropDomain.ToSpawnIsTriggerProp(ctx);

    }

    public static void Next_Level_hasEnemy_1(GameContext ctx) {
        // 2 的关卡
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

        ctx.gameEntity.Init();
        RoleDomain.Spawn(ctx, pos, RoleConst.PLAYER);
        MapDomain.Spawn(ctx, 3);
        // 左上角
        PropDomain.Spawn(ctx, new Vector2(-11.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-11.5f, 6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-11.5f, 5), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-10.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-9.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-9.5f, 6), PropConst.OBSTACLE, 0);
        // 左下角
        PropDomain.Spawn(ctx, new Vector2(-11.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-11.5f, -5), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-11.5f, -4), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-10.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-9.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(-9.5f, -5), PropConst.OBSTACLE, 0);
        //右下角
        PropDomain.Spawn(ctx, new Vector2(11.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(11.5f, -5), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(11.5f, -4), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(10.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(9.5f, -6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(9.5f, -5), PropConst.OBSTACLE, 0);

        //右上角
        PropDomain.Spawn(ctx, new Vector2(11.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(11.5f, 6), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(11.5f, 5), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(10.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(9.5f, 7), PropConst.OBSTACLE, 0);
        PropDomain.Spawn(ctx, new Vector2(9.5f, 6), PropConst.OBSTACLE, 0);

        PropDomain.ToSpawnIsTriggerProp(ctx);


        // 生成敌人
        RoleDomain.Spawn(ctx, new Vector2(-10.5f, 6), RoleConst.ENEMY_1);
        RoleDomain.Spawn(ctx, new Vector2(-10.5f, -5), RoleConst.ENEMY_1);
        RoleDomain.Spawn(ctx, new Vector2(10.5f, -5), RoleConst.ENEMY_1);
        RoleDomain.Spawn(ctx, new Vector2(10.5f, 6), RoleConst.ENEMY_1);

        ctx.gameEntity.currentEnemyCount = 4;
    }

    public static void Next_Level_hasEnemy_2(GameContext ctx) {
        // 1 的关卡
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

        ctx.gameEntity.Init();
        RoleDomain.Spawn(ctx, pos, RoleConst.PLAYER);
        MapDomain.Spawn(ctx, 3);
        PropDomain.ToSpawnIsTriggerProp(ctx);
        RoleDomain.Spawn(ctx, new Vector2(3, 3), RoleConst.ENEMY_2);
        RoleDomain.Spawn(ctx, new Vector2(1, 2), RoleConst.ENEMY_2);
        RoleDomain.Spawn(ctx, new Vector2(4, 3), RoleConst.ENEMY_2);
        RoleDomain.Spawn(ctx, new Vector2(5, 1), RoleConst.ENEMY_2);


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

            if (role.isRole) {

                RoleDomain.Move(ctx, role, ctx.moduleInput.moveAxis, dt);
                RoleDomain.ToSpawnBullet(ctx, role, dt);
                RoleDomain.Player_Die(ctx, role);
            } else if (role.typeID == RoleConst.ENEMY_1) {
                RoleDomain.EnemyToAttack(ctx, role, dt);
                RoleDomain.Enemy_1_Die(ctx, role);
            } else if (role.typeID == RoleConst.ENEMY_2) {
            
            }

            RoleFSMConteoller.Tick(ctx, role, dt);


        }


        // bullet
        int bulletLen = ctx.bulletRespository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {
            BulletEntity bullet = bullets[i];

            if (bullet.isRoleBullet) {
                BulletDomain.Move(ctx, bullet, dt);
                BulletDomain.BeyondBoundaryToUnSpawn(ctx, bullet);
                BulletDomain.MoveDistanceToUnSpawn(ctx, bullet, dt);
                BulletDomain.player_BulletTouchEnemy(ctx, bullet);
            } else if (bullet.isEnemyBullet) {
                BulletDomain.BeyondBoundaryToUnSpawn(ctx, bullet);
                BulletDomain.Enemy_1_Move(ctx, bullet, roles[0], dt);
                BulletDomain.Enemy1_BulletTouchPlayer(ctx, bullet);

            }



        }






        int propLen = ctx.propRespository.TakeAll(out PropEntity[] props);
        for (int i = 0; i < propLen; i++) {
            PropEntity prop = props[i];
            PropDomain.BoolisTrigger(ctx, prop);
            PropDomain.EnterNextLevel(ctx, prop);

            PropDomain.ChestSpawnGold(ctx, prop);
            // 问题
            // PropDomain.SetRigidbody(ctx, prop);
        }

        if (ctx.gameEntity.currentEnemyCount == 0) {
            ctx.gameEntity.isSpawnChest = true;
            ctx.gameEntity.currentEnemyCount = 1;
        }


        if (ctx.gameEntity.isSpawnChest) {
            PropDomain.Spawn(ctx, new Vector2(3, 1), PropConst.CHEST, 0);
            ctx.gameEntity.isSpawnChest = false;
        }


        // 清除全部

        if (ctx.gameEntity.isEnterLevel) {
            RoleDomain.CloseAll(ctx);
            BulletDomain.CloseAll(ctx);
            PropDomain.CloseAll(ctx);
            MapDomain.CloseAll(ctx);
            if (ctx.gameEntity.nextLevelID == 2) {
                Next_Level_hasEnemy_1(ctx);
            } else if (ctx.gameEntity.nextLevelID == 1) {
                Next_Level_hasEnemy_2(ctx);
            } else {
                Next_Level(ctx);
            }
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
