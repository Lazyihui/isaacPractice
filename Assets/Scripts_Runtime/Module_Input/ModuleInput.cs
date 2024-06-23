using System;
using UnityEngine;


public class ModuleInput {
    public Vector2 moveAxis;




    public ModuleInput() {
        moveAxis = Vector2.zero;
    }

    public void ProcessMove() {
        
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

        this.moveAxis = moveAxis;

     }

}