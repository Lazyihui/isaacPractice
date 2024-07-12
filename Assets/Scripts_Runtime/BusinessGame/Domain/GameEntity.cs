using System;
using UnityEngine;

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

    public int currentEnemyCount;

    public bool isSpawnChest;


    public int bossEnemyCount;

    // 暂时没有随机关卡一关一关加
    public int LevelID;

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
        currentEnemyCount = 1;
        isEnterLevel = false;
        bossEnemyCount = 0;
    }

    public void NoUpdata() {
        hp = 3;
        goldCount = 3;
        bombCount = 0;
        keyCount = 0;
        LevelID = 0;
    }

}