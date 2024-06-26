using System;
using System.Collections.Generic;
using UnityEngine;


public static class UIApp {


    public static void Panel_Heart_Open(UIContext ctx, int hp) {
        Panel_Heart panel = ctx.panel_Heart;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Heart", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Heart not found");
                return;
            }

            GameObject go = GameObject.Instantiate(prefab, ctx.canvas.transform);
            panel = go.GetComponent<Panel_Heart>();
            panel.Ctor();
            ctx.panel_Heart = panel;
        }
        panel.Init(hp);
        panel.Show();
    }

    public static void Panel_Heart_Unpdate(UIContext ctx, int hp) {
        Panel_Heart panel = ctx.panel_Heart;
        if (panel == null) {
            return;
        }
        panel.Init(hp);
    }
}
