using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utility
{
    public static void DrowDebugPoint(Vector3 pos)
    {
        Debug.DrawLine(pos + new Vector3(0.1f, 0), pos + new Vector3(-0.1f, 0));
        Debug.DrawLine(pos + new Vector3(0, 0.1f), pos + new Vector3(0.0f, -0.1f));
    }

    public static void DrowDebugLine(params object[] paramList)
    {
        List<Vector3> posList = new List<Vector3>();
        for (int i = 0; i < paramList.Length; i++)
        {
            posList.Add((Vector3)paramList[i]);
        }

        DrowDebugLine(posList);

    }

    public static void DrowDebugLine(List<Vector3> posList)
    {
        if (posList.Count < 2)
        {
            return;
        }

        for (int i = 0; i < posList.Count - 1; i++)
        {
            Debug.DrawLine(posList[i], posList[i + 1]);
        }
    }
}
