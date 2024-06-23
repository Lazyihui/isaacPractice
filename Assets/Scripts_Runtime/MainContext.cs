using System;
using UnityEngine;


public class MainContex {

    public GameContext gameContext;

    // module

    public ModuleInput moduleInput;


    public AssetsContext assetsContext;

    public MainContex() {
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        assetsContext = new AssetsContext();

    }

    public void Inject() {
        gameContext.Inject(moduleInput, assetsContext);
     }
}