using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlayManager : MonoBehaviour
{
    public Image overlayImage;
    private float r;
    private float g;
    private float b;
    private float a;

    void Start()
    {
        r = overlayImage.color.r;
        g = overlayImage.color.g;
        b = overlayImage.color.b;
        a = overlayImage.color.a;
    }

    public void UpdateDamageOverlay(float lifeValue)
    {
        a = 1f - (lifeValue/100f);
        a = Mathf.Clamp(a, 0, 1f);
        AdjustColor();
    }

    private void AdjustColor()
    {
        Color c = new Color(r,g,b,a);
        overlayImage.color = c;
    }
}
