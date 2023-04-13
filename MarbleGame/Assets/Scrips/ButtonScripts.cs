using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonScripts : MonoBehaviour
{
    Button yourButton;
    public GameObject sampleObject;
    public KeyCode triggerKey;
    public Camera buildCam;
    public GameObject marble;
    public GameObject spawn;
    Vector3 spawnPos;
    bool bluePressed = false;
    bool canPress = true;
    public GameObject[] blueObstacle;


    void Awake()
    {
        buildCam.gameObject.SetActive(true);
        yourButton = GetComponent<Button>();
        spawnPos = spawn.gameObject.transform.position;
        spawnPos.y += 3;
    }

    void Update()
    {
        if(Input.GetKeyDown(triggerKey))
        {
            yourButton.onClick.Invoke();
        }
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    public void AddObject()
    {
        // Forward vector to see where the camera is facing
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camCoords = Camera.main.transform.position;
        Vector3 itemCoords = new Vector3(0, 0, 0);

        // new Vector3(camCoords.x, camCoords.y + 5, camCoords.z + 5);
        // Case where all coords are +
        if ((camForward.x >= 0.0 || camForward.x == 0.0) && (camForward.y >= 0.0 || camForward.y == 0) && (camForward.z >= 0.0 || camForward.z == 0.0)) {
            itemCoords = new Vector3(camCoords.x + 15, camCoords.y, camCoords.z + 10);
        }
        // Case where only x is -, y and z +
        else if (camForward.x < 0 && (camForward.y >= 0.0 || camForward.y == 0) && (camForward.z >= 0.0 || camForward.z == 0.0))
        {
            itemCoords = new Vector3(camCoords.x - 15, camCoords.y, camCoords.z + 10);
        }
        // Case where x and y -, z +
        else if (camForward.x < 0 && camForward.y < 0 && (camForward.z >= 0.0 || camForward.z == 0.0))
        {
            itemCoords = new Vector3(camCoords.x - 15, camCoords.y, camCoords.z + 10);
        }
        // Case where all components -
       else if(camForward.x < 0 && camForward.y < 0 && camForward.z < 0)
       {
            itemCoords = new Vector3(camCoords.x - 15, camCoords.y, camCoords.z - 10);
        }
       else if((camForward.x >= 0.0 || camForward.x == 0.0) && (camForward.y >= 0.0 || camForward.y == 0) && camForward.z < 0)
        {
            itemCoords = new Vector3(camCoords.x + 15, camCoords.y, camCoords.z - 10);
        }
        else if ((camForward.x >= 0.0 || camForward.x == 0.0) && camForward.y < 0 && camForward.z < 0)
        {
            itemCoords = new Vector3(camCoords.x + 15, camCoords.y, camCoords.z - 10);
        }
        else if(camForward.x < 0 && (camForward.y >= 0.0 || camForward.y == 0) && camForward.z < 0)
        {
            itemCoords = new Vector3(camCoords.x - 15, camCoords.y, camCoords.z - 10);
        }
        else if((camForward.x >= 0.0 || camForward.x == 0.0) && camForward.y < 0 && (camForward.z >= 0.0 || camForward.z == 0.0)) {
            itemCoords = new Vector3(camCoords.x + 15, camCoords.y, camCoords.z + 10);
        }
        else
        {
            if(camForward.x < 0 || camForward.y < 0 || camForward.z < 0)
            {
                itemCoords = new Vector3(camCoords.x - 15, camCoords.y, camCoords.z - 10);
            }
            else
            {
                itemCoords = new Vector3(camCoords.x + 15, camCoords.y, camCoords.z + 10);
            }

        }
            GameObject newSpawn = Instantiate(sampleObject, itemCoords, sampleObject.transform.rotation);
    }
    public void startGame()
    {
       GameObject newSpawn = Instantiate(marble, spawnPos, marble.transform.rotation);
    }

    public void BlueObstacles()
    {
        float lerpDuration = 3;
        if(!bluePressed && canPress)
        {
            canPress = false;
            foreach (GameObject obj in blueObstacle) {
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.x += 5;
                StartCoroutine(Lerp(obj, startPos, newPos, lerpDuration));
            }
            bluePressed = !bluePressed;
        }
        else if (canPress)
        {
            canPress = false;
            foreach (GameObject obj in blueObstacle)
            {
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.x -= 5;
                StartCoroutine(Lerp(obj, startPos, newPos, lerpDuration));
            }
            bluePressed = !bluePressed;
        }

    }

    IEnumerator Lerp(GameObject obj, Vector3 startPos, Vector3 newPos, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, newPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = newPos;
        canPress = true;
    }
}
