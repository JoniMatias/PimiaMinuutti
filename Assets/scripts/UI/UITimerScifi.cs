using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimerScifi : UITimerGeneric {

    public TextMeshProUGUI label;

    void Update() {

        int minutes = ((int)hp.time) / 60;
        int seconds = ((int)hp.time) % 60;

        string timeStr = "<mspace=0.5em>" + minutes + " " + seconds + "</mspace>";

        label.text = timeStr;

    }
}