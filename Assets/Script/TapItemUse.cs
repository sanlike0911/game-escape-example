using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapItemUse : TapCollider
{
    public GameObject ItemImage;
    public GameObject[] ActiveObjects;

    protected override void OnTap()
    {
        base.OnTap();

        if (ItemImage.activeSelf)
        {
            ItemImage.SetActive(false);
            gameObject.SetActive(false);

            foreach (var obj in ActiveObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
