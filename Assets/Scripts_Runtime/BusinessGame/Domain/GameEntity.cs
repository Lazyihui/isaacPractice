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

    public int figureCount;

    public int goldCount;

    public int bombCount;

    public int keyCount;


    public GameEntity() {

    }

    public void Init() {
        restFixTime = 0;
        roleRecordID = 0;
        bulletRecordID = 0;
        mapRecordID = 0;
        propRecordID = 0;
        nextLevelID = 0;
        figureCount = 3;
        isEnterLevel = false;
    }

    public void NoUpdata() {
        hp = 3;
        goldCount =3;
        bombCount = 0;
        keyCount = 0;
    }

}