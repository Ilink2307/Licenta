using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFade : MonoBehaviour
{
    public float waitTillFade;
    public float fadeSpeedImage;
    public float fadeSpeedText;
    public Image image;
    public TMP_Text text;

    bool imageFadeDone = false;
    bool textFadeDone = false;

    // Update is called once per frame
    void Update()
    {
        if(waitTillFade > 0)
        {
            waitTillFade -= Time.deltaTime;
        }
        else
        {
            if(image.color.a > 0)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - fadeSpeedImage * Time.deltaTime);
            }
            else
            {
                imageFadeDone = true;
            }

            if(text.color.a > 0)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - fadeSpeedText * Time.deltaTime);
            }
            else
            {
                textFadeDone = true;
            }
        }

        if(imageFadeDone && textFadeDone)
        {
            gameObject.SetActive(false);
        }
    }
}
