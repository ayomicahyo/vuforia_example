using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChanger : MonoBehaviour
{
    [SerializeField]
    private List<ObjectData> _objects = new List<ObjectData>();

    [SerializeField]
    private Cardboard _cardBoard;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private ObjectShowedData[] _patternToShow = new ObjectShowedData[0];

    [SerializeField, ReadOnly]
    private int _patternValue = 0;

    private void Start()
    {
        ShowPattern(0);
    }

    private void ShowPattern(int index)
    {
        _cardBoard.gameObject.SetActive(false);

        foreach (var obj in _objects)
        {
            obj.Object.SetActive(false);
        }

        var pattern = _patternToShow[index];

        foreach (var objKey in pattern.ObjectToShow)
        {
            foreach (var objIndex in _objects)
            {
                if (objIndex.Key == objKey)
                {
                    objIndex.Object.SetActive(true);
                }
            }
        }

        if (pattern.ShowCard)
        {
            _cardBoard.gameObject.SetActive(true);
            _cardBoard.ChangeText(pattern.TitleText, pattern.DescText);
        }

        _patternValue = index;
    }

    [Button]
    public void PlayAudio()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _patternToShow[_patternValue].Audio;
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }

    [Button]
    public void NextObject()
    {
        var pattern = _patternValue + 1;

        if (pattern == _patternToShow.Length)
        {
            pattern = 0;
        }

        ShowPattern(pattern);
    }

    [Button]
    public void PreviousObject()
    {
        var pattern = _patternValue - 1;

        if (pattern < 0)
        {
            pattern = _patternToShow.Length - 1;
        }

        ShowPattern(pattern);
    }
}

[Serializable]
public class ObjectData
{
    [SerializeField]
    private string _key;

    [SerializeField]
    private GameObject _object;
    public string Key => _key;
    public GameObject Object => _object;
}

[Serializable]
public class ObjectShowedData
{
    [SerializeField]
    private List<string> _objectToShow = new List<string>();

    [SerializeField]
    private bool _showCardBoard;

    [AllowNesting]
    [SerializeField, ShowIf("ShowCardBoard")]
    private string _titleText;

    [AllowNesting]
    [SerializeField, ShowIf("ShowCardBoard")]
    private string _descText;

    [SerializeField]
    private AudioClip _audio;

    public List<string> ObjectToShow => _objectToShow;
    public bool ShowCard => _showCardBoard;
    public string TitleText => _titleText;
    public string DescText => _descText;
    public AudioClip Audio => _audio;

    private bool ShowCardBoard()
    {
        return _showCardBoard;
    }
}