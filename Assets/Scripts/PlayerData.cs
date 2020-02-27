using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData (Knight_Parallax Knight_Parallax)
    {
        position = new float[2];
        position[0] = Knight_Parallax.transform.position.x;
        position[1] = Knight_Parallax.transform.position.y;

    }

}
