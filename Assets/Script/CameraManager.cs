using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    /// <summary>CameraManager �C���X�^���X</summary>
    public static CameraManager Instance {  get; private set; }

    /// <summary>���݂̃J�����ʒu��</summary>
    public string CurrentCameraPositionName { get; private set; }

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;
    public GameObject ButtonUp;

    /// <summary>
    /// �J�����ʒu���N���X
    /// </summary>
    private class CameraPositionInfo
    {
        /// <summary>�J�����ʒu</summary>
        public Vector3 Position { get; set; }
        /// <summary>�J�����̊p�x</summary>
        public Vector3 Rotation { get; set; }
        /// <summary>�{�^���̈ړ���</summary>
        public MoveNames MoveNames { get; set; }
    }

    /// <summary>
    /// �{�^���ړ���N���X
    /// </summary>
    private class MoveNames
    {
        /// <summary>���{�^���������̈ʒu��</summary>
        public string Left { get; set; }
        /// <summary>�E�{�^���������̈ʒu��</summary>
        public string Right { get; set; }
        /// <summary>���{�^���������̈ʒu��</summary>
        public string Back { get; set; }
        /// <summary>��{�^���������̈ʒu��</summary>
        public string Up { get; set; }
    }

    private readonly Dictionary<string, CameraPositionInfo> _CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
    {
        {
            "Door", // �ʒu����: ���[���P�@�h�A����
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
            "RoomRight1",�@// �ʒu����: ���[���P�@�G���A�E
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
            "RoomRight2",�@// �ʒu����: ���[���P�@�G���A�E
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
            "RoomRight2Chair",�@// �ʒu����: ���[���P�@�G���A�E(�֎q)
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
            "RoomLeft1",�@// �ʒu����: ���[���P�@�G���A��
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
            "RoomLeft2",�@// �ʒu����: ���[���P�@�G���A��
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
            "RoomSandBox",�@// �ʒu����: ���[���P�@�G���A��(����)
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
            "RoomItemBox",�@// �ʒu����: ���[���P�@�G���A��(�A�C�e���{�b�N�X)
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
            "RoomItemBoxOpen",�@// �ʒu����: ���[���P�@�G���A��(�A�C�e���{�b�N�X)
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
    /// �{�^���\����Ԃ̍X�V����
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
