using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UpdateScore : MonoBehaviour
{
    private Text _text;

    public void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
    }
}
