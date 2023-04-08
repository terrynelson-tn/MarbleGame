//Module 8 Midterm Project --- SaveSlotsMenu.cs by Sebastian Ulloa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    [Header("Confirmation Popup")]
    [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        //Case -- Loading Game
        if (isLoadingGame)
        {
            DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            SaveGameAndLoadScene();
        }

        //Case -- New Game, Save has Data
        else if (saveSlot.HasData)
        {
            confirmationPopupMenu.ActivateMenu(
                "Overwrite this slot to start a new game? (Will erase all prior data on this file)",
                //Function to execute if YES is selected
                () => {
                    DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistenceManager.Instance.NewGame();
                    SaveGameAndLoadScene();
                },
                //Function to execute if NO is selected
                () => {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }
        //Case -- New Game, Save has No Data
        else
        {
            DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            DataPersistenceManager.Instance.NewGame();
            SaveGameAndLoadScene();
        }


    }

    private void SaveGameAndLoadScene()
    {
        DataPersistenceManager.Instance.SaveGame();

        SceneManager.LoadSceneAsync("Level 1");
    }



    public void OnClearClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        confirmationPopupMenu.ActivateMenu(
            "Are you sure you want to delete this Save Data?",
            //Function to execute if YES is selected
            () =>
            {
                DataPersistenceManager.Instance.DeleteProfileData(saveSlot.GetProfileId());
                ActivateMenu(isLoadingGame);
            },
            //Function to execute if NO is selected
            () =>
            {
                ActivateMenu(isLoadingGame);
            }
        );
    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }


    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();

        backButton.interactable = true;

        GameObject firstSelected = backButton.gameObject;
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }else
            {
                saveSlot.SetInteractable(true);
                if (firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected = saveSlot.gameObject;
                }
            }
        }

        Button firstSelectedButton = firstSelected.GetComponent<Button>();
        this.SetFirstSelected(firstSelectedButton);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
