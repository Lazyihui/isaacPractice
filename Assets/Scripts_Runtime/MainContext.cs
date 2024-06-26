using System;
using UnityEngine;


public class MainContex {

    public GameContext gameContext;

    // module

    public ModuleInput moduleInput;


    public AssetsContext assetsContext;

    public TemplateContext templateContext;

    public UIContext uiContext;

    public MainContex() {
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        assetsContext = new AssetsContext();
        templateContext = new TemplateContext();
        uiContext = new UIContext();

    }

    public void Inject(Canvas canvas) {
        gameContext.Inject(moduleInput, assetsContext,templateContext,uiContext);
        uiContext.Inject(canvas, assetsContext);
     }
}