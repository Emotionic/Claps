using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogViewer : MonoBehaviour
{
    public int LogLimit = 15;
    public int DisplaySeconds = 5;
    public bool StopLog = true;

    public void AddLine(string _str)
    {
        if (Texts.Count >= LogLimit) Texts.Dequeue();
        Texts.Enqueue(new Pair<string, int>(_str, System.Environment.TickCount));
    }

    public void Clear()
    {
        Texts.Clear();
    }

    private Queue<Pair<string, int>> Texts = new Queue<Pair<string, int>>();

    // Use this for initialization
    private void Start()
    {
        AdjustSize();

    }

    // Update is called once per frame
    private void Update()
    {
        string _text = null;

        while (!StopLog && Texts.Count != 0 && Texts.Peek().Second + DisplaySeconds * 1000 <= System.Environment.TickCount)
        {
            Texts.Dequeue();
        }

        foreach (var t in Texts)
        {
            _text = _text == null ? t.First : t.First + "\n" + _text;
        }

        this.GetComponent<Text>().text = _text;
        AdjustSize();
    }

    private void AdjustSize()
    {
        var text = GetComponent<Text>();
        text.rectTransform.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
    }
}
