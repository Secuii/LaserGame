using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

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
                YouNeedRoomNameMenu.SetActive(true);
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
            YouNeedRoomNameMenu.SetActive(false);
        }

        //Delete menu
        public void DeleteRoomButton()
        {
            if (GameController.ButtonRoomPresset != null)
            {
                DeleteMenu.SetActive(true);
            }
            else
            {
                YouNeedSelectMenu.SetActive(true);
            }
        }

        public void DeleteRoomConfirmation()
        {
            ButtonCreation.DeleteButtons(GameController.ButtonRoomPresset);
            DeleteMenu.SetActive(false);
        }

        public void DeleteRoomDenegate()
        {
            DeleteMenu.SetActive(false);
            GameController.ButtonRoomPresset = null;
        }
        public void YouNeedToSelectRoomConfirmation()
        {
            YouNeedSelectMenu.SetActive(false);
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
                YouNeedSelectMenu.SetActive(true);
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
                DuplicateMenu.SetActive(true);
            }
            else
            {
                YouNeedSelectMenu.SetActive(true);
            }
        }

        public void DuplicateConfirmation()
        {
            GameController.RoomPressetList.Add(GameController.ButtonRoomPresset);
            GameController.ButtonRoomPresset = null;
            ButtonCreation.ResetButtons();
            DuplicateMenu.SetActive(false);

        }

        public void DuplicateDenegate()
        {
            DuplicateMenu.SetActive(false);
        }

        //Restore list
        public void RestoreListTodDefault()
        {
            DoYouRestoreList.SetActive(true);
        }

        public void RestoreConfirm()
        {
            ButtonCreation.UndoRoomButtonList();
            DoYouRestoreList.SetActive(false);
        }

        public void RestoreDenegate()
        {
            DoYouRestoreList.SetActive(false);
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
                YouNeedSelectMenu.SetActive(true);
            }
        }

        //Assort List
        //public void AssortList(int _index)
        //{
        //    switch (_index)
        //    {
        //        case 0:
        //            Debug.Log("Default");
        //            break;
        //        case 1:
        //            Debug.Log("Stars");
        //            break;
        //        case 2:
        //            Debug.Log("RoomName");
        //            break;
        //        case 3:
        //            Debug.Log("UsserName ");
        //            GameController.SortListByName();
        //            break;
        //    }

        //}

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

        [SerializeField] private GameObject MainMenu = null;
        [SerializeField] private GameObject CreateMenu = null;
        [SerializeField] private GameObject PlayMenu = null;

        [SerializeField] private GameObject DeleteMenu = null;
        [SerializeField] private GameObject YouNeedSelectMenu = null;
        [SerializeField] private GameObject YouNeedPasswordMenu = null;
        [SerializeField] private GameObject WrongPasswordMenu = null;
        [SerializeField] private GameObject CorrectPasswordMenu = null;
        [SerializeField] private GameObject DoYouRestoreList = null;
        [SerializeField] private GameObject DuplicateMenu = null;
        [SerializeField] private GameObject CreateSettingMenu = null;
        [SerializeField] private GameObject YouNeedRoomNameMenu = null;
        [SerializeField] private GameObject ExitWIthoutSave = null;


        [SerializeField] private GameObject CreateMode = null;
        [SerializeField] private GameObject Scenario = null;

        [SerializeField] private InputField PasswordField = null;
        [SerializeField] private InputField RoomName = null;


        [SerializeField] private ButtonCreation ButtonCreation = null;
        [SerializeField] private GameController GameController = null;
    }
}