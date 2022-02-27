using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitterBtnPress : SoundEmitter
{
    public KeyCode BtnToPress;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(BtnToPress))
            PlaySound();
    }
}
