using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    public static Singleton instance;
    public GameEvent gameEvent;
    public GameModule gameModule;
    private readonly string SAVE_KEY = "SaveKey";

    public Singleton()
    {

    }

    /// <summary>
    /// 初期化
    /// </summary>
    public static void Initialize()
    {
        if(instance == null)
        {
        instance = new Singleton();
        }
        instance.Reset();
    }

    public void Reset()
    {
        gameEvent = new GameEvent();
        gameModule = new GameModule();
    }
}
