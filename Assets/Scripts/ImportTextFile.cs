using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ImportTextFile : MonoBehaviour
{
    // public Transform displayText;
    // public GameObject textFile;
    public List<string> filelines;

    public void Convert()
    {
        string textRead = Application.streamingAssetsPath + "/unityPianoSongs" + ".txt";

        filelines = File.ReadAllLines(textRead).ToList();
    }
}
