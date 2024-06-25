using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    MainContex ctx;
    bool isTearDown = false;
    void Awake() {
        ctx = new MainContex();
        

        // === init===

        // === Load===
        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfra.Load(ctx.templateContext);

        // === Inject===
        ctx.Inject();

        // new game
        Game_Business.New_Game(ctx.gameContext);


    }

    void Update() {
        float dt = Time.deltaTime;

        Game_Business.Tick(ctx.gameContext, dt);
    }
    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
        TemplateInfra.Unload(ctx.templateContext);
    }
}
