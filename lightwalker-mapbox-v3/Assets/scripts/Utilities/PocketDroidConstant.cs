using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class PocketDroidConstant
{
    public static string SCENE_WORLD = "World";
    public static string SCENE_CAPTURE = "Capture";
    private static int coinsNum = 0;
    private static int objectType = -1; // object类型  0:monster; 1: trap; 2: coins
    private static string hintText = "";

    public static int COINSNUM
    {
        get
        {
            return coinsNum;
        }

        set
        {
            coinsNum = value;
        }
    }

    public static int OBJECTTYPE
    {
        get
        {
            return objectType;
        }

        set
        {
            objectType = value;
        }
    }

    public static string HINTTEXT
    {
        get
        {
            return hintText;
        }

        set
        {
            hintText = value;
        }
    }

}
