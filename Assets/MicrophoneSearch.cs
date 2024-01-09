using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneSearch : MonoBehaviour
{
    public TMPro.TextMeshProUGUI DisplayText;
    
    // Update is called once per frame
    void Update()
    {
        string output = "";

        for(int i = 0; i < Microphone.devices.Length; ++i)
        {
            output += "Microphone.devices[";
            output += i;
            output += "] = ";
            output += Microphone.devices[i];
            output += "\n";
        }

        DisplayText.text = output;
    }
}
