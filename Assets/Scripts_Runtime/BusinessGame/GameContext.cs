using System;
using UnityEngine;


public class GameContext {

    public GameEntity gameEntity;


    // Respostory
    public RoleRespository roleRespository;


    // inject
    public ModuleInput moduleInput;

    public AssetsContext assetsContext;



    public GameContext() {
        roleRespository = new RoleRespository();
        gameEntity = new GameEntity();
    }


    public void Inject(ModuleInput input, AssetsContext assets) {
        this.moduleInput = input;
        this.assetsContext = assets;
    }

}