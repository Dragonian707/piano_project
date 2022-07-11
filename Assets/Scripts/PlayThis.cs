using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayThis : MonoBehaviour
{
    private Note note;
    private Button[] buttons;
    public Text text;
    public Text current;
    // private string[] pair;
    List<string> fromTextFile;
    private List<string> noteToPlay = new List<string>();
    private List<float> delay = new List<float>();
    public Dictionary<string, Button> notes = new Dictionary<string, Button>();
    // Start is called before the first frame update
    void Start()
    {
        note = GetComponent<Note>();

        fromTextFile = FindObjectOfType<ImportTextFile>().filelines;
        
        for (int i = 0; i < note.buttons.Count; i++)
        {
            notes.Add(note.buttonname[i], note.buttons[i]);
        }

        buttons = FindObjectsOfType<Button>();
        //for (int i = 0; i < pair.Length; i++)
        //{
        //    noteToPlay = pair[i].Split(',');
        //}


        //StartCoroutine(Play());
    }

    public void ConvertString(Text text)
    {
        delay.Clear();
        noteToPlay.Clear();
        fromTextFile = FindObjectOfType<ImportTextFile>().filelines;
        string toDisplay = "";
        
        
        //pair = text.text.Split( );

        foreach (string toPlay in fromTextFile)
        {
            // Debug.Log(toPlay.Length);
            if (toPlay.Contains(","))
            {
                toDisplay += toPlay + " ";
                string[] midway = toPlay.Split(',');
                for (int i = 0; i < 2; i++)
                {
                    if (float.TryParse(midway[i], out float number))
                    {
                        delay.Add(number);
                    }
                    else
                    {
                        noteToPlay.Add(midway[i]);
                    }
                }
            }
        }
        // Debug.Log(noteToPlay.Count);
        // Debug.Log(delay.Count);
        text.text = toDisplay;
    }

    public void PlayString()
    {
        foreach (Button butt in buttons)
        {
            butt.interactable = false;
        }
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        for (int i = 0; i < noteToPlay.Count; i++)
        {
            current.text = "playing: " + noteToPlay[i];
            notes[noteToPlay[i]].onClick.Invoke();
            notes[noteToPlay[i]].interactable = !notes[noteToPlay[i]].interactable;
            yield return new WaitForSeconds(delay[i]);
        }
        foreach (Button butt in buttons)
        {
            butt.interactable = true;
        }
        current.text = "playing:";
    }
}
