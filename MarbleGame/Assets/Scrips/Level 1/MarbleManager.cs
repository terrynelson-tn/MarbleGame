//Final Project --- MarbleManager.cs by Sebastian Ulloa

using Unity.VisualScripting;
using UnityEngine;

public class MarbleManager : MonoBehaviour, IDataPersistence
{
    public GameObject PlayerMarble;

    public Material[] marbleMaterials;

    [SerializeField] private int SelectedMarble;

    //Load Selected Marble Variant
    public void Start()
    {
        DataPersistenceManager.Instance.LoadGame();
        SelectedMarbleMaterial();
    }

    public void LoadData(GameData data)
    {
        this.SelectedMarble = data.MarbleVariant;
    }

    public void SaveData(GameData data)
    {
    }

    private void SelectedMarbleMaterial()
    {
        PlayerMarble.GetComponent<MeshRenderer>().material = SelectedMarble switch
        {
            1 => marbleMaterials[0],
            2 => marbleMaterials[1],
            3 => marbleMaterials[2],
            4 => marbleMaterials[3],
            5 => marbleMaterials[4],
            6 => marbleMaterials[5],
            _ => marbleMaterials[0],
        };
    }
}