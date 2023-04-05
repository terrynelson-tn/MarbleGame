//Final Project --- MarbleSelectionCameraManager.cs by Sebastian Ulloa

using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class MarbleSelectionCameraManager : MonoBehaviour, IDataPersistence
{
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;
    public CinemachineVirtualCamera cam4;
    public CinemachineVirtualCamera cam5;
    public CinemachineVirtualCamera cam6;

    public CinemachineVirtualCamera startCamera;
    private CinemachineVirtualCamera currentCamera;

    private int MarbleVariant = 1;

    private void Start()
    {
        currentCamera = startCamera;

        for (int i = 0; i < cameras.Length; i++) 
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            int VariableNumber = 1;
            switch (VariableNumber)
            {
                case 1 when currentCamera == cam1:
                    SwitchCam(cam2);
                    MarbleVariant = 2;
                    break;

                case 1 when currentCamera == cam2:
                    SwitchCam(cam3);
                    MarbleVariant = 3;
                    break;

                case 1 when currentCamera == cam3:
                    SwitchCam(cam4);
                    MarbleVariant = 4;
                    break;

                case 1 when currentCamera == cam4:
                    SwitchCam(cam5);
                    MarbleVariant = 5;
                    break;

                case 1 when currentCamera == cam5:
                    SwitchCam(cam6);
                    MarbleVariant = 6;
                    break;

                case 1 when currentCamera == cam6:
                    MarbleVariant = 6;
                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            int VariableNumber = 1;
            switch (VariableNumber)
            {
                case 1 when currentCamera == cam6:
                    SwitchCam(cam5);
                    MarbleVariant = 5;
                    break;

                case 1 when currentCamera == cam5:
                    SwitchCam(cam4);
                    MarbleVariant = 4;
                    break;

                case 1 when currentCamera == cam4:
                    SwitchCam(cam3);
                    MarbleVariant = 3;
                    break;

                case 1 when currentCamera == cam3:
                    SwitchCam(cam2);
                    MarbleVariant = 2;
                    break;

                case 1 when currentCamera == cam2:
                    SwitchCam(cam1);
                    MarbleVariant = 1;
                    break;

                case 1 when currentCamera == cam1:
                    MarbleVariant = 1;
                    break;
            }

        }

    }

    public void SwitchCam(CinemachineVirtualCamera newCamera)
    {
        currentCamera = newCamera;

        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void EnterLevel()
    {
        DataPersistenceManager.Instance.SaveGame();
        SceneManager.LoadSceneAsync("Level 1");
    }


    public void LoadData(GameData data)
    {
    }

    public void SaveData(GameData data)
    {
        data.MarbleVariant = this.MarbleVariant;
    }
}
