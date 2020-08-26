using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using UnityEditor;

namespace HUD
{
    public class HUDNavigation : MonoBehaviour
    {

        //Main menu
        public void CreateButton()
        {
            ActiveMenus(false, true, false);
        }

        public void PlayButton()
        {
            ActiveMenus(false, false, true);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        //General back button
        public void BackButton()
        {
            ActiveMenus(true, false, false);
            GameController.ButtonRoomPresset = null;
        }

        //Create menu
        public void CreateRoomButton()
        {
            CreateSettingMenu.SetActive(true);
        }

        public void CancelCreateNewRoom()
        {
            CreateSettingMenu.SetActive(false);
        }
        public void CreateNewRoom()
        {
            if (RoomName.text == "")
            {
                PopupBackWindow.SetActive(true);
                ChangePopupBackText("You need to add a room name");  
            }
            else
            {
                CreateMenu.SetActive(false);
                CreateSettingMenu.SetActive(false);
                Scenario.SetActive(true);
                CreateMode.SetActive(true);
            }
        }
        public void YouNeedRoomNameBack()
        {
            PopupBackWindow.SetActive(false);
        }

        //Delete menu
        public void DeleteRoomButton()
        {
            if (GameController.ButtonRoomPresset != null)
            {
                PopupYesNokWindow.SetActive(true);
                ChangePopupYesNoText("Are you sure you want to delete this room ?");
                PopupName = "delete";
            }
            else
            {
                PopupBackWindow.SetActive(true);
                ChangePopupBackText("You need to select a room first");

            }
        }

        public void PopupBackButton()
        {
            PopupBackWindow.SetActive(false);
        }

        //Edit menu
        public void EditRoomButton()
        {
            if (GameController.ButtonRoomPresset != null)
            {
                YouNeedPasswordMenu.SetActive(true);
            }
            else
            {
                PopupBackWindow.SetActive(true);
                ChangePopupBackText("You need to select a room first");
            }
        }

        public void EnterEditPassword()
        {
            if (PasswordField.text == GameController.ButtonRoomPresset.RoomPassword)
            {
                CorrectPasswordMenu.SetActive(true);
            }
            else
            {
                WrongPasswordMenu.SetActive(true);
            }
        }

        public void ContinueToEditMode()
        {
            //TODO EDIT MODE
            YouNeedPasswordMenu.SetActive(false);
            PasswordField.text = null;
        }

        public void WrongPassWordBack()
        {
            WrongPasswordMenu.SetActive(false);
            PasswordField.text = null;
        }

        public void CancelEditRoom()
        {
            YouNeedPasswordMenu.SetActive(false);
            PasswordField.text = null;
            GameController.ButtonRoomPresset = null;
        }

        //Duplicate room
        public void DuplicateRoomButton()
        {
            if (GameController.ButtonRoomPresset != null)
            {
                PopupYesNokWindow.SetActive(true);
                ChangePopupYesNoText("Are you sure you want to duplicate this room?");
                PopupName = "duplicate";
            }
            else
            {
                PopupBackWindow.SetActive(true);
                ChangePopupBackText("You need to select a room first");
            }
        }


        //Restore list
        public void RestoreListTodDefault()
        {
            PopupYesNokWindow.SetActive(true);
            ChangePopupYesNoText("Do you want to restore the list?");
            PopupName = "restore";
        }

        // DUPLICATE OR RESTORE YES NO

        public void PopupYesConfirmation()
        {
            switch (PopupName)
            {
                case "duplicate":
                    GameController.RoomPressetList.Add(GameController.ButtonRoomPresset);
                    GameController.ButtonRoomPresset = null;
                    ButtonCreation.ResetButtons();
                    PopupYesNokWindow.SetActive(false);
                    break;
                case "restore":
                    ButtonCreation.UndoRoomButtonList();
                    PopupYesNokWindow.SetActive(false);
                    break;
                case "delete":
                    ButtonCreation.DeleteButtons(GameController.ButtonRoomPresset);
                    PopupYesNokWindow.SetActive(false);
                    break;
            }
            PopupName = "";
        }

        public void PopupNoConfirmation()
        {
            switch (PopupName)
            {
                case "duplicate":
                    PopupYesNokWindow.SetActive(false);
                    break;
                case "restore":
                    PopupYesNokWindow.SetActive(false);
                    break;
                case "delete":
                    GameController.ButtonRoomPresset = null;
                    PopupYesNokWindow.SetActive(false);
                    break;
            }
            PopupName = "";
        }

        //Play menu
        public void PlayRoomButton()
        {
            if (GameController.ButtonRoomPresset != null)
            {
                //TODO PLAY MODE
                PlayMenu.SetActive(false);
            }
            else
            {
                PopupBackWindow.SetActive(true);
                ChangePopupBackText("You need to select a room first");
            }
        }

        public void ActiveMenus(bool _menu, bool _create, bool _play)
        {
            MainMenu.SetActive(_menu);
            CreateMenu.SetActive(_create);
            PlayMenu.SetActive(_play);
        }

        //ROOM CREATOR
        public void ExitRoomCreator(bool _notSaved)
        {
            MainMenu.SetActive(true);
            CreateMode.SetActive(false);
            Scenario.SetActive(false);
            if (_notSaved)
            {
                ExitWIthoutSave.SetActive(true);
            }
        }

        private void ChangePopupBackText(string _text)
        {
            PopupBackText.text = _text;
        }

        private void ChangePopupYesNoText(string _text)
        {
            PopupYesNoText.text = _text;
        }

        //MENU LOGING

        public void CreateNewAccount()
        {
            CreateAccountCanvas.SetActive(true);
            MainScreenCanvas.SetActive(false);
        }

        public void ConnectAccount()
        {
            ConnnectAccountCanvas.SetActive(true);
            MainScreenCanvas.SetActive(false);
        }

        public void BackMainScreenCanvas()
        {
            ConnnectAccountCanvas.SetActive(false);
            CreateAccountCanvas.SetActive(false);
            MainScreenCanvas.SetActive(true);
        }

        public void ExitMainGame()
        {
            Application.Quit();
        }

        //CREATE ACCOUNT LOGIC

        public void CreateUsser()
        {
            if (usserRepeatPasswordInput.text == usserPasswordInput.text)
            {
                FirebaseUsserAuth.CreateNewUsser(usserMailInput.text, usserPasswordInput.text);
            }
            else
            {
                ChangePopupBackText("You insert a different password");
                PopupBackWindow.SetActive(true);
            }
        }

        public void ConectUsser()
        {
            FirebaseUsserAuth.ConectCreatedUsser(usserMailInput.text, usserPasswordInput.text);
        }

        [SerializeField] private InputField usserMailInput;
        [SerializeField] private InputField usserPasswordInput;
        [SerializeField] private InputField usserRepeatPasswordInput;

        [SerializeField] private GameObject CreateAccountCanvas;
        [SerializeField] private GameObject ConnnectAccountCanvas;
        [SerializeField] private GameObject MainScreenCanvas;


        [SerializeField] private GameObject MainMenu = null;
        [SerializeField] private GameObject CreateMenu = null;
        [SerializeField] private GameObject PlayMenu = null;

        [SerializeField] private GameObject YouNeedPasswordMenu = null;
        [SerializeField] private GameObject WrongPasswordMenu = null;
        [SerializeField] private GameObject CorrectPasswordMenu = null;
        [SerializeField] private GameObject CreateSettingMenu = null;
        [SerializeField] private GameObject ExitWIthoutSave = null;



        private string PopupName = "";
        [SerializeField] private GameObject PopupBackWindow = null;
        [SerializeField] private Text PopupBackText = null;

        [SerializeField] private GameObject PopupYesNokWindow = null;
        [SerializeField] private Text PopupYesNoText = null;


        [SerializeField] private GameObject CreateMode = null;
        [SerializeField] private GameObject Scenario = null;

        [SerializeField] private InputField PasswordField = null;
        [SerializeField] private InputField RoomName = null;


        [SerializeField] private ButtonCreation ButtonCreation = null;
        [SerializeField] private GameController GameController = null;
    }
}