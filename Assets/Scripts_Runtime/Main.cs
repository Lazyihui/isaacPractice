using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    MainContex ctx;
    void Awake() {
        ctx = new MainContex();
        Debug.Log("Hello World!");
    }

    void Update() {
        float dt = Time.deltaTime;

        Game_Business.Tick(ctx.gameContext, dt);
    }
}
