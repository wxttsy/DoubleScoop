using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayTrack("Track_1");
        AudioManager.instance.PlayClip("Clip_1");
        AudioManager.instance.PlaySound("UI");
        Debug.Log("TesterPlayed");
    }
}
