using System;
using UnityEngine;


public class GameContext {

    public GameEntity gameEntity;


    // Respostory
    public RoleRespository roleRespository;

    public BulletRespository bulletRespository;

    public MapRespository mapRespository;

    public PropRespository propRespository;

    // inject
    public ModuleInput moduleInput;

    public AssetsContext assetsContext;

    public  TemplateContext templateContext;


    public GameContext() {
        gameEntity = new GameEntity();


        roleRespository = new RoleRespository();
        bulletRespository = new BulletRespository();
        mapRespository = new MapRespository();
        propRespository = new PropRespository();
    }


    public void Inject(ModuleInput input, AssetsContext assets,TemplateContext templateContext) {
        this.moduleInput = input;
        this.assetsContext = assets;
        this.templateContext = templateContext;
    }

}