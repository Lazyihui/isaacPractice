using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    MainContex ctx;
    void Awake() {
        ctx = new MainContex();

        // === init===

        // === Load===
        ModuleAssets.Load(ctx.assetsContext);

        // === Inject===
        ctx.Inject();

        // new game
        Game_Business.New_Game(ctx.gameContext);


    }

    void Update() {
        float dt = Time.deltaTime;

        Game_Business.Tick(ctx.gameContext, dt);
    }
}
