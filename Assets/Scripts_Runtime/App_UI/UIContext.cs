using System;
using UnityEngine;

public class UIContext {
    //inject
    public Canvas canvas;

    public AssetsContext assetsContext;
    // 

    public UIEvent uiEvent;

    public Panel_Heart panel_Heart;


    public UIContext() {
        uiEvent = new UIEvent();
    }

    public void Inject(Canvas canvas, AssetsContext assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
    }
}