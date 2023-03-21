using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJudge : MonoBehaviour
{
    private bool _IsOpen = false;

    public TapObjectChange[] TapChanges;
    public int[] AnserIndexes;
    public string OpenPositionName;
    public GameObject OpenCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenPositionName != CameraManager.Instance.CurrentCameraPositionName) return;

        if (_IsOpen) return;

        for(int i = 0; i < TapChanges.Length; i++) {
            if (TapChanges[i].Index != AnserIndexes[i])
                return;
        }

        // ˆÈ‰º‚Í³‰ðƒ‹[ƒg
        _IsOpen = true;
        foreach (var TapChange in TapChanges)
        {
            TapChange.enabled = false;
            TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;

        }

        Invoke(nameof(CameraMove), 0.5f);

    }

    private void CameraMove()
    {
        CameraManager.Instance.ChangeCameraPosition(OpenPositionName);
        OpenCollider.SetActive(true);
    }
}
