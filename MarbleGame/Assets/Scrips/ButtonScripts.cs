using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonScripts : MonoBehaviour
{
    public Button yourButton;
    public Button yourButton2;
    public GameObject sampleObject;
    public Camera buildCam;
    public GameObject marble;
    public GameObject spawn;
    Vector3 spawnPos;
    bool horizPressed = false;
    bool vertPressed = false;
    public GameObject[] Obstacles;


    void Start()
    { 
        spawnPos = spawn.transform.position;
        Debug.Log(spawnPos.x + " " + spawnPos.y + " " + spawnPos.z);
        spawnPos.y += 3;
    }
/*    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }*/

 /*   public void AddObject()
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
    }*/
    public void startGame()
    {
       GameObject newSpawn = Instantiate(marble, spawnPos, marble.transform.rotation);
    }

    public void moveHorizontal()
    {
        float lerpDuration = 3;
        if(!horizPressed)
        {
            yourButton.interactable = false;
            yourButton2.interactable = false;
            foreach (GameObject obj in Obstacles) {
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.x += 5;
                StartCoroutine(LerpHoriz(obj, startPos, newPos, lerpDuration));
            }
            horizPressed = !horizPressed;
        }
        else
        {
            yourButton.interactable = false;
            yourButton2.interactable = false;
            foreach (GameObject obj in Obstacles)
            {
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.x -= 5;
                StartCoroutine(LerpHoriz(obj, startPos, newPos, lerpDuration));
            }
            horizPressed = !horizPressed;
        }

    }

    IEnumerator LerpHoriz(GameObject obj, Vector3 startPos, Vector3 newPos, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, newPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = newPos;
        yourButton.interactable = true;
        yourButton2.interactable = true;

    }

    public void moveVertical()
    {
        float lerpDuration = 3;
        if (!vertPressed)
        {
            yourButton.interactable = false;
            yourButton2.interactable = false;
            foreach (GameObject obj in Obstacles)
            {
                yourButton.interactable = false;
                yourButton2.interactable = false;
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.y += 5;
                StartCoroutine(LerpVert(obj, startPos, newPos, lerpDuration));
            }
            vertPressed = !vertPressed;
        }
        else
        {
            yourButton.interactable = false;
            yourButton2.interactable = false;
            foreach (GameObject obj in Obstacles)
            {
                yourButton.interactable = false;
                yourButton2.interactable = false;
                Vector3 startPos = obj.transform.position;
                Vector3 newPos = startPos;
                newPos.y -= 5;
                StartCoroutine(LerpVert(obj, startPos, newPos, lerpDuration));
            }
            vertPressed = !vertPressed;
           
        }

    }

    IEnumerator LerpVert(GameObject obj, Vector3 startPos, Vector3 newPos, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, newPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = newPos;
        yourButton.interactable = true;
        yourButton2.interactable = true;
    }
}
