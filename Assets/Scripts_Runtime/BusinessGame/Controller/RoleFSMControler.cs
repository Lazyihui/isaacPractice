using System;
using UnityEngine;


public static class RoleFSMConteoller {

    public static void Tick(GameContext ctx, RoleEntity role, float dt) {
        RoleFSMStatus status = role.status;

        if (status == RoleFSMStatus.Idle) {
            Player_Idle(ctx, role, dt);
        }
        Any_State(ctx, role, dt);
    }

    static void Any_State(GameContext ctx, RoleEntity role, float dt) {

        if (role.typeID == RoleConst.PLAYER) {
            Player_Any_State(ctx, role, dt);
        }

        if (role.typeID == RoleConst.ENEMY_3) {
            Enemy_Any_State(ctx, role, dt);
        }


    }

    static void Player_Any_State(GameContext ctx, RoleEntity role, float dt) {
        Vector2 face = ctx.moduleInput.faceAxis;

        if (face.x > 0) {
            role.animatior.Play("right");
        } else if (face.x < 0) {
            role.animatior.Play("left");
        } else if (face.y > 0) {
            role.animatior.Play("back");
        }

        if (face.x == 0 && face.y == 0) {
            role.Enter_Idle();
        }


    }

    static void Enemy_Any_State(GameContext ctx, RoleEntity role, float dt) {
        RoleEntity player = ctx.roleRespository.Find(player => player.typeID == RoleConst.PLAYER);

        Vector2 dir = player.transform.position - role.transform.position;
        dir.Normalize();
        if (dir.x > 0) {
            role.transform.localScale = new Vector3(1, 1, 1);
        } else if (dir.x < 0) {
            role.transform.localScale = new Vector3(-1, 1, 1);
        }

    }



    static void Player_Idle(GameContext ctx, RoleEntity role, float dt) {
        if (role.idle_isEntering) {
            role.idle_isEntering = false;
            role.animatior.Play("front");
        }
    }

    static void Enemy_Idle(GameContext ctx, RoleEntity role, float dt) {
        if (role.idle_isEntering) {
            role.idle_isEntering = false;
            role.animatior.Play("Eneny1_Idle");
        }
    }

}