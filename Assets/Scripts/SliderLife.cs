using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLife : MonoBehaviour
{
    public Slider sliderPlayer;

    // Update is called once per frame
    void Update()
    {
        sliderPlayer.value = GameManager.Instance.life;
    }
}
