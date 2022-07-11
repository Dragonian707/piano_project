using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public List<string> buttonname = new List<string>();
    // Start is called before the first frame update
    public Note(Button button, string index)
    {
        buttons.Add(button);
        buttonname.Add(index);
    }
}
