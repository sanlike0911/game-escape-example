using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    /// <summary>CameraManager インスタンス</summary>
    public static CameraManager Instance {  get; private set; }

    /// <summary>現在のカメラ位置名</summary>
    public string CurrentCameraPositionName { get; private set; }

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;
    public GameObject ButtonUp;

    /// <summary>
    /// カメラ位置情報クラス
    /// </summary>
    private class CameraPositionInfo
    {
        /// <summary>カメラ位置</summary>
        public Vector3 Position { get; set; }
        /// <summary>カメラの角度</summary>
        public Vector3 Rotation { get; set; }
        /// <summary>ボタンの移動先</summary>
        public MoveNames MoveNames { get; set; }
    }

    /// <summary>
    /// ボタン移動先クラス
    /// </summary>
    private class MoveNames
    {
        /// <summary>左ボタン押下時の位置名</summary>
        public string Left { get; set; }
        /// <summary>右ボタン押下時の位置名</summary>
        public string Right { get; set; }
        /// <summary>下ボタン押下時の位置名</summary>
        public string Back { get; set; }
        /// <summary>上ボタン押下時の位置名</summary>
        public string Up { get; set; }
    }

    private readonly Dictionary<string, CameraPositionInfo> _CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
    {
        {
            "Door", // 位置名称: ルーム１　ドア正面
            new CameraPositionInfo
            {
                Position = new Vector3(0,100,100),
                Rotation = new Vector3(0,0,0),
                MoveNames = new MoveNames
                {
                    Left = "RoomLeft1",
                    Right = "RoomRight1",
                }
            }
        },
        {
            "RoomRight1",　// 位置名称: ルーム１　エリア右
            new CameraPositionInfo
            {
                Position = new Vector3(-31,75,67),
                Rotation = new Vector3(-7,46,0),
                MoveNames = new MoveNames
                {
                    Left = "Door",
                    Right = "RoomRight2",
                }
            }
        },
        {
            "RoomRight2",　// 位置名称: ルーム１　エリア右
            new CameraPositionInfo
            {
                Position = new Vector3(0,100,100),
                Rotation = new Vector3(0,70,0),
                MoveNames = new MoveNames
                {
                    Left = "RoomRight1",
                }
            }
        },
        {
            "RoomRight2Chair",　// 位置名称: ルーム１　エリア右(椅子)
            new CameraPositionInfo
            {
                Position = new Vector3(862,92,365),
                Rotation = new Vector3(3,88,0),
                MoveNames = new MoveNames
                {
                    Back = "RoomRight2",
                }
            }
        },
        {
            "RoomLeft1",　// 位置名称: ルーム１　エリア左
            new CameraPositionInfo
            {
                Position = new Vector3(-96,95,175),
                Rotation = new Vector3(-7,-42,0),
                MoveNames = new MoveNames
                {
                    Left = "RoomLeft2",
                    Right = "Door",
                }
            }
        },
        {
            "RoomLeft2",　// 位置名称: ルーム１　エリア左
            new CameraPositionInfo
            {
                Position = new Vector3(-550,200,100),
                Rotation = new Vector3(0,-70,0),
                MoveNames = new MoveNames
                {
                    Right = "RoomLeft1",
                }
            }
        },
        {
            "RoomSandBox",　// 位置名称: ルーム１　エリア左(砂場)
            new CameraPositionInfo
            {
                Position = new Vector3(-890,205,85),
                Rotation = new Vector3(37,-75,0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft2",
                }
            }
        },
        {
            "RoomItemBox",　// 位置名称: ルーム１　エリア左(アイテムボックス)
            new CameraPositionInfo
            {
                Position = new Vector3(-1000,130,530),
                Rotation = new Vector3(7,-92,0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft2",
                }
            }
        },
        {
            "RoomItemBoxOpen",　// 位置名称: ルーム１　エリア左(アイテムボックス)
            new CameraPositionInfo
            {
                Position = new Vector3(-1000,130,530),
                Rotation = new Vector3(7,-92,0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft2",
                }
            }
        },
    };

    public void ChangeCameraPosition(string positionName)
    {
        if(positionName == null) return;
       
        CurrentCameraPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfoes[CurrentCameraPositionName].Position;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfoes[CurrentCameraPositionName].Rotation);

        updateButtonDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Door");

        ButtonLeft.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Left);
        });
        ButtonRight.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Right);
        });
        ButtonBack.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Back);
        });
        ButtonUp.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Up);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ボタン表示状態の更新処理
    /// </summary>
    private void updateButtonDisplay()
    {
        if (_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Back == null) 
            ButtonBack.SetActive(false);
        else ButtonBack.SetActive(true);

        if (_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Left == null)
            ButtonLeft.SetActive(false);
        else ButtonLeft.SetActive(true);

        if (_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Right == null)
            ButtonRight.SetActive(false);
        else ButtonRight.SetActive(true);

        if (_CameraPositionInfoes[CurrentCameraPositionName].MoveNames.Up == null)
            ButtonUp.SetActive(false);
        else ButtonUp.SetActive(true);
    }

}
