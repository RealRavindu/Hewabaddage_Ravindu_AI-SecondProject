using ParadoxNotion.Design;
using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreText.text = value.ToString();
            StartCoroutine(ScoreIncreaseAnimation());
        }
    }
    private float _score;

    public TextMeshProUGUI scoreText;
    public float animationLength;
    [SliderField(0, 1)] public float saturationAmplitude;
    public AnimationCurve saturationCurve;

    private float c_hue;
    private float c_saturation;
    private float c_value;

    private void Start()
    {
        Color.RGBToHSV(scoreText.color,out c_hue, out c_saturation, out c_value);
    }
    private IEnumerator ScoreIncreaseAnimation()
    {
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / animationLength;
            scoreText.color = Color.HSVToRGB(c_hue, c_saturation + saturationCurve.Evaluate(t)*saturationAmplitude, c_value);
            yield return null;
        }
    }

}
