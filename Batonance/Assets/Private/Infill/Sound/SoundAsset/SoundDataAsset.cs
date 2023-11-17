using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TemplateSoundDataAsset", menuName = "ScriptableObject/CreateSoundDataAsset")]
public class SoundDataAsset : ScriptableObject
{
    public string soundKey = "Key";
    public AudioClip soundFile;
    public int bpm;
    public int measure;
    public float offset;
    public TextAsset notesData;
}
