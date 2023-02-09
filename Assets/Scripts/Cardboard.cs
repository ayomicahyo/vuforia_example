using TMPro;
using UnityEngine;

public class Cardboard : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _titleText;

    [SerializeField]
    private TextMeshPro _descriptionText;

    public void ChangeText(string title, string desc)
    {
        _titleText.text = title;
        _descriptionText.text = desc;
    }
}
