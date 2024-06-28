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

    // repository
    public FigureEleRespository figureEleRespository;
    public int figureEleRecordID;
    public UIContext() {

        uiEvent = new UIEvent();
        // repo
        figureEleRespository = new FigureEleRespository();
        figureEleRecordID = 0;

    }

    public void Inject(Canvas canvas, AssetsContext assetsContext, TemplateContext templateContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
        this.templateContext = templateContext;
    }
}