using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class LogTeleport : MonoBehaviour
{
    public int numberOfTeleports = 0;
    public string mat = "none";

    public void teleported(GameObject chosenMat)
    {
        numberOfTeleports++;
        mat = chosenMat.name;
    }

    public void setStart()
    {
        numberOfTeleports = 0;
        mat = "none";
    }


}
