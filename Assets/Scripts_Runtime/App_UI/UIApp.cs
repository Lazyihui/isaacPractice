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

    public static void Panel_Heart_Close(UIContext ctx) {
        Panel_Heart panel = ctx.panel_Heart;
        if (panel == null) {
            return;
        }
        panel.TearDown();
        ctx.panel_Heart = null;
    }

    // figure
    public static void Panel_Figure_Open(UIContext ctx) {
        Panel_Figure panel = ctx.panel_Figure;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Figure", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Figure not found");
                return;
            }
            GameObject go = GameObject.Instantiate(prefab, ctx.canvas.transform);
            panel = go.GetComponent<Panel_Figure>();
            panel.Ctor();
            ctx.panel_Figure = panel;
        }
        panel.Show();
    }

    public static void Panel_FigureElement_Add(UIContext ctx, int typeID) {
        Panel_Figure panel = ctx.panel_Figure;
        if (panel == null) {
            return;
        }
        bool has = ctx.templateContext.figures.TryGetValue(typeID, out FigureElementTM tm);
        if (!has) {
            Debug.LogError("Panel_FigureElement_Add not found");
            return;
        }
        panel.AddElement(tm.sprite, tm.txt);

    }
    public static void Panel_Figure_Close(UIContext ctx) {
        Panel_Figure panel = ctx.panel_Figure;
        if (panel == null) {
            return;
        }
        panel.TearDown();
        ctx.panel_Figure = null;
    }
}
