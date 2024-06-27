using System;
using UnityEngine;

public class UIContext {
    //inject
    public Canvas canvas;

    public AssetsContext assetsContext;

    public TemplateContext templateContext;
    // 

    public UIEvent uiEvent;

    public Panel_Heart panel_Heart;

    public Panel_Figure panel_Figure;


    public UIContext() {
        uiEvent = new UIEvent();
    }

    public void Inject(Canvas canvas, AssetsContext assetsContext, TemplateContext templateContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
        this.templateContext = templateContext;
    }
}