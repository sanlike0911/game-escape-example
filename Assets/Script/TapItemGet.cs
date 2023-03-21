using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapItemGet : TapCollider
{
    public GameObject ItemImage;

    protected override void OnTap()
    {
        base.OnTap();

        ItemImage.SetActive(true);
        gameObject.SetActive(false);
    }
}
