using System;
using UnityEngine;


public class GameContext {

    public GameEntity gameEntity;


    // Respostory
    public RoleRespository roleRespository;

    public BulletRespository bulletRespository;

    public MapRespository mapRespository;


    // inject
    public ModuleInput moduleInput;

    public AssetsContext assetsContext;



    public GameContext() {
        gameEntity = new GameEntity();


        roleRespository = new RoleRespository();
        bulletRespository = new BulletRespository();
        mapRespository = new MapRespository();
    }


    public void Inject(ModuleInput input, AssetsContext assets) {
        this.moduleInput = input;
        this.assetsContext = assets;
    }

}