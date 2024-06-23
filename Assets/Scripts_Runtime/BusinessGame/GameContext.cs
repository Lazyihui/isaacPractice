using System;
using UnityEngine;


public class GameContext {

   public GameEntity gameEntity;


    // Respostory
    public RoleRespository roleRespository;



    public GameContext() {
        roleRespository = new RoleRespository();
        gameEntity = new GameEntity();
    }


    public void Inject() { }

}