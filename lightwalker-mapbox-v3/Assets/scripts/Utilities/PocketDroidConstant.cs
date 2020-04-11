using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class PocketDroidConstant
{
    public static string SCENE_WORLD = "World";
    public static string SCENE_CAPTURE = "Capture";
    private static int coinsNum = 0;
    private static int pointsNum = 0;
    private static int objectType = -1; // object类型  0:monster; 1: fixedTrap; 2:trap; 3: coins; 
    private static string hintText = "";
	private static int leftTime = -1;
    private static int eyeNum = 0;
    private static int trapNum = 0;
    private static bool monsterAcitvated = false;
    private static bool destroyCurrent = false;
    private static bool usingMagicEye = false;
    public static List<Clickable> shownObjects = new List<Clickable>();

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

    public static int POINTSNUM
    {
        get
        {
            return pointsNum;
        }

        set
        {
            pointsNum = value;
        }
    }

    public static int EYENUM
    {
        get
        {
            return eyeNum;
        }

        set
        {
            eyeNum = value;
        }
    }

    public static int TRAPNUM
    {
        get
        {
            return trapNum;
        }

        set
        {
            trapNum = value;
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

	public static int LEFTTIME
	{
		get
		{
			return leftTime;
		}

		set
		{
			leftTime = value;
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

    public static bool MONSTRER_ACTIVATED
    {
        get
        {
            return monsterAcitvated;
        }

        set
        {
            monsterAcitvated = value;
        }
    }

    public static bool DETORY_CURRENT
    {
        get
        {
            return destroyCurrent;
        }

        set
        {
            destroyCurrent = value;
        }
    }

    public static bool USING_MAGICEYE
    {
        get
        {
            return usingMagicEye;
        }

        set
        {
            usingMagicEye = value;
        }
    }

}
