using UnityEngine;
using HUD;

namespace Core
{
    public class ButtonCreation : MonoBehaviour
    {
        public void CreateButtons()
        {
            char[] archDelim = { '\n' };
            string[] dataRooms = FileTextEditor.ReadFileText().Split(archDelim, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataRooms.Length; i++)
            {
                GameObject CreateButton = Instantiate(RoomButtonPrefabs, CreateRoomContent.transform);
                CreateButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.RoomPressetList[i];
                GameObject PlayButton = Instantiate(RoomButtonPrefabs, PlayRoomContent.transform);
                PlayButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.RoomPressetList[i];
            }
        }

        public void ResetButtons()
        {
            for (int i = 0; i < CreateRoomContent.transform.childCount; i++)
            {
                Destroy(CreateRoomContent.transform.GetChild(i).gameObject);
                Destroy(PlayRoomContent.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < GameController.RoomPressetList.Count; i++)
            {
                GameObject CreateButton = Instantiate(RoomButtonPrefabs, CreateRoomContent.transform);
                CreateButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.RoomPressetList[i];
                GameObject PlayButton = Instantiate(RoomButtonPrefabs, PlayRoomContent.transform);
                PlayButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.RoomPressetList[i];
            }
        }

        public void UndoRoomButtonList()
        {
            for (int i = 0; i < CreateRoomContent.transform.childCount; i++)
            {
                Destroy(CreateRoomContent.transform.GetChild(i).gameObject);
                Destroy(PlayRoomContent.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < GameController.TemporalList.Count; i++)
            {
                GameObject CreateButton = Instantiate(RoomButtonPrefabs, CreateRoomContent.transform);
                CreateButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.TemporalList[i];
                GameObject PlayButton = Instantiate(RoomButtonPrefabs, PlayRoomContent.transform);
                PlayButton.GetComponent<RoomButtonDisplay>().RoomPresset = GameController.TemporalList[i];
            }
        }

        public void SaveRoomButtons()
        {
            FileTextEditor.EditRoomFile(GameController.RoomPressetList);
            GameController.TemporalList.Clear();
            for (int i = 0; i < GameController.RoomPressetList.Count; i++)
            {
                GameController.TemporalList.Add(GameController.RoomPressetList[i]);
            }
        }

        public void DeleteButtons(RoomPresset _roomPresset)
        {
            for (int i = 0; i < GameController.RoomPressetList.Count; i++)
            {
                if (GameController.RoomPressetList[i] == _roomPresset)
                {
                    GameController.RoomPressetList.RemoveAt(i);
                    break;
                }
            }
            ResetButtons();
        }

        [SerializeField] private GameController GameController = null;

        [SerializeField] private GameObject PlayRoomContent = null;
        [SerializeField] private GameObject CreateRoomContent = null;

        [SerializeField] private GameObject RoomButtonPrefab = null;
        public GameObject RoomButtonPrefabs { get => RoomButtonPrefab; }


    }
}