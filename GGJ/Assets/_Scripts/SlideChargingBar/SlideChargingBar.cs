using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideChargingBar : Singleton<SlideChargingBar>
{
    
    [SerializeField] private TextMeshPro loadingText;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private float speed = 1.0f;
    
    private void Start()
    {
        loadingSlider.onValueChanged.AddListener(UpdateLoadingBar);
    }

    IEnumerator IncreaseValue()
    {
        while (loadingSlider.value < 1)
        {
            loadingSlider.value += Time.deltaTime / speed;
            yield return null;
        }
        
        gameObject.SetActive(false);
        
    }

    void UpdateLoadingBar(float value)
    {
        loadingText.text = (value * 100).ToString("0") + "%";
    }

    public void StartChargingBar()
    {
        StartCoroutine(IncreaseValue());
    }
}

