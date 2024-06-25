using System;


public class GameEntity{

    public float restFixTime;

    // id

    public int roleRecordID;

    public int bulletRecordID;

    public int mapRecordID;

    public int propRecordID;    

    public int nextLevelID;

    public GameEntity() {
        restFixTime = 0;
        roleRecordID = 0;
        bulletRecordID = 0;
        mapRecordID = 0;
        propRecordID = 0;
        nextLevelID =0;
    }
}