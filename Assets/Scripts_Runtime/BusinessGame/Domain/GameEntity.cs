using System;


public class GameEntity {

    public float restFixTime;

    // id

    public int roleRecordID;

    public int bulletRecordID;

    public int mapRecordID;

    public int propRecordID;

    public int nextLevelID;
    //是否进入下一关
    public bool isEnterLevel;

    // 面板的数值
    public int hp;

    public int magic;


    public GameEntity() {

    }

    public void Init() {
        restFixTime = 0;
        roleRecordID = 0;
        bulletRecordID = 0;
        mapRecordID = 0;
        propRecordID = 0;
        nextLevelID = 0;
        hp = 3; 
        isEnterLevel = false;
    }

}