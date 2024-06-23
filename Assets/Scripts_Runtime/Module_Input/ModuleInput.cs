using System;
using UnityEngine;


public class ModuleInput {
    public Vector2 moveAxis;

    public Vector2 faceAxis;




    public ModuleInput() {
        moveAxis = Vector2.zero;
        faceAxis = Vector2.zero;
    }

    public void ProcessMove() {
        // 移动
        Vector2 moveAxis = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            moveAxis.y = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveAxis.y = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            moveAxis.x = 1;
        }
        moveAxis.Normalize();
        this.moveAxis = moveAxis;

        // 面向
        Vector2 faceAxis = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            faceAxis.y = 1;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            faceAxis.y = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            faceAxis.x = -1;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            faceAxis.x = 1;
        }

        this.faceAxis = faceAxis;
    }

}