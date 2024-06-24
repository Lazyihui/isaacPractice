using System;
using UnityEngine;


public static class RoleFSMConteoller {

    public static void Tick(GameContext ctx, RoleEntity role, float dt) {
        RoleFSMStatus status = role.status;

        if (status == RoleFSMStatus.Idle) {
            Idle(ctx, role, dt);
        }
        Any_State(ctx, role, dt);
    }

    static void Any_State(GameContext ctx, RoleEntity role, float dt) {

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

        Vector2 moveDir = ctx.moduleInput.moveAxis;
        if (moveDir.x > 0) {
            role.animatior.Play("right");
        } else if (moveDir.x < 0) {
            role.animatior.Play("left");
        }else if (moveDir.y > 0) {
            role.animatior.Play("back");
        }

        if(moveDir.x == 0 && moveDir.y == 0) {
            role.Enter_Idle();
        }




    }


    static void Idle(GameContext ctx, RoleEntity role, float dt) {
        if (role.idle_isEntering) {
            role.idle_isEntering = false;
            role.animatior.Play("front");
        }
    }



}