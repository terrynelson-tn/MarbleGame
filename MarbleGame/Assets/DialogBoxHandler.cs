using UnityEngine;
using UnityEngine.UI;

public class DialogBoxHandler : MonoBehaviour
{
    public GameObject dialogBox;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogBox.SetActive(false);
        }
    }
}
