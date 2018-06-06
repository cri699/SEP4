using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOption : MonoBehaviour {

    void Start()
    {
        AudioListener.volume = 1;
        GetComponent<Slider>().value = 1;
    }

    public void OnValueChanged()
    {
        AudioListener.volume = GetComponent<Slider>().value;
    }

}
