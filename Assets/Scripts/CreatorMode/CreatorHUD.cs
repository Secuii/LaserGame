using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Core;
using HUD;

namespace CreatorMode
{
    public class CreatorHUD : MonoBehaviour
    {

        public void GetItemPrefabInVariant()
        {
            actualPrefab = EventSystem.current.currentSelectedGameObject.GetComponent<CreatorButtonsVariantPrefab>().ItemPrefab;
            VariantButtons.GetComponent<Animator>().SetBool("Play", !VariantButtons.GetComponent<Animator>().GetBool("Play"));
        }

        public void VariantButtonsAnimationDisplay()
        {
            if (!EventSystem.current.currentSelectedGameObject.GetComponent<VariantButtonAnim>().VariantButtonAnimBool)
            {
                for (int i = 0; i < ItemButtons.transform.childCount; i++)
                {
                    ItemButtons.transform.GetChild(i).GetComponent<VariantButtonAnim>().VariantButtonAnimBool = false;
                }

                EventSystem.current.currentSelectedGameObject.GetComponent<VariantButtonAnim>().VariantButtonAnimBool = true;
                if (!VariantButtons.GetComponent<Animator>().GetBool("Play"))
                {
                    VariantButtons.GetComponent<Animator>().SetBool("Play", !VariantButtons.GetComponent<Animator>().GetBool("Play"));
                }
            }
            else
            {
                VariantButtons.GetComponent<Animator>().SetBool("Play", !VariantButtons.GetComponent<Animator>().GetBool("Play"));
            }
        }

        public void SaveCreatorRoom()
        {
            if (SavedRoom)
            {
                GameController.RoomPressetList.RemoveAt(GameController.RoomPressetList.Count - 1);
                GameController.RoomPressetList.Add(GameController.CreatorRoomPresset);

            }
            else
            {
                GameController.RoomPressetList.Add(GameController.CreatorRoomPresset);
                SavedRoom = true;
            }
            ButtonCreation.ResetButtons();
        }

        public void ExitRoomCreator()
        {
            if (!SavedRoom)
            {
                HudNaviggation.ExitRoomCreator(true);
            }
            else
            {
                RoomCreatorMode.RemoveAllItems();
                HudNaviggation.ExitRoomCreator(false);
            }

        }


        [SerializeField] private GameObject VariantButtons = null;
        [SerializeField] private GameObject ItemButtons = null;

        [SerializeField] private GameController GameController = null;
        [SerializeField] private HUDNavigation HudNaviggation = null;
        [SerializeField] private RoomCreatorMode RoomCreatorMode = null;
        [SerializeField] private ButtonCreation ButtonCreation = null;

        private bool SavedRoom = false;
        public GameObject actualPrefab;
    }
}