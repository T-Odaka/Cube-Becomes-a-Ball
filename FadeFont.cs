using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeFont : MonoBehaviour
{
    public void TMPFadeinFadeout(TextMeshProUGUI textMeshPro)
    {
        float alpha;

        alpha = Mathf.Sin(Time.time);
        if(alpha <= 0)
        {
            alpha *= -1;
        }
        textMeshPro.color = new Color(0,0,0,alpha);
    }
}
