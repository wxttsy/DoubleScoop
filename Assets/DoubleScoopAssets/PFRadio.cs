using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFRadio : MonoBehaviour
{

    bool isplaying = false;

    private void FixedUpdate()
    {
        if (isplaying == false)
        {
            PickSong();
            isplaying = true;
            Invoke("ResetSong", 180f);
        }
    }

    void ResetSong()
    {
        isplaying = false;
    }

    void PickSong()
    {
        int songNumber = Random.Range(1, 3);

        if (songNumber == 1)
        {
            AudioManager.instance.PlayTrack("Track_Static");
            Invoke("PlaySong1", 1f);
        }
        else if(songNumber == 2)
        {
            AudioManager.instance.PlayTrack("Track_Static");
            Invoke("PlaySong2", 1f);
        }
        else if (songNumber == 3)
        {
            AudioManager.instance.PlayTrack("Track_Static");
            Invoke("PlaySong3", 1f);
        }
    }

    void PlaySong1()
    {
        AudioManager.instance.PlayTrack("Track_1");
    }

    void PlaySong2()
    {
        AudioManager.instance.PlayTrack("Track_2");
    }

    void PlaySong3()
    {
        AudioManager.instance.PlayTrack("Track_3");
    }
}
