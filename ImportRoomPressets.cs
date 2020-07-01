using UnityEngine;
using System.Collections.Generic;


namespace Core
{
    public class ImportRoomPressets : MonoBehaviour
    {
        public void CreatePressetsFromFile()
        {
            char[] archDelim = { '\n' };
            char[] semicolonDelim = { ';' };
            char[] guionDelim = { '-' };
            char[] comaDelim = { ',' };

            //Get File from Class FileReader
            string[] dataRooms = FileTextEditor.ReadFileText().Split(archDelim, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataRooms.Length; i++)
            {

                string[] row = dataRooms[i].Split(semicolonDelim, System.StringSplitOptions.RemoveEmptyEntries);
                RoomPresset RoomPresset = ScriptableObject.CreateInstance<RoomPresset>();

                int.TryParse(row[0], out RoomPresset.RoomImage);
                int.TryParse(row[1], out RoomPresset.RoomStars);
                RoomPresset.RoomName = row[2];
                RoomPresset.UsserName = row[3];

                int.TryParse(row[4], out RoomPresset.ItemsInRoom);

                // WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                RoomPresset.ItemsRoom = new GameObject[RoomPresset.ItemsInRoom];

                string[] _items = row[5].Split(comaDelim, System.StringSplitOptions.RemoveEmptyEntries);

                
                for (int j = 0; j < RoomPresset.ItemsInRoom; j++)
                {
                    string[] _itemsArray = _items[j].Split(guionDelim, System.StringSplitOptions.RemoveEmptyEntries);

                    RoomPresset.ItemsRoom[j] = GameItems(_itemsArray[0])[int.Parse(_itemsArray[1])];


                }

                // WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                RoomPresset.ItemsPosition = new Vector2[RoomPresset.ItemsInRoom];
                string[] _itemsPositionSeparation = row[6].Split(comaDelim, System.StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < RoomPresset.ItemsInRoom; j++)
                {
                    string[] _itemsPosition = _itemsPositionSeparation[j].Split(guionDelim, System.StringSplitOptions.RemoveEmptyEntries);
                    RoomPresset.ItemsPosition[j].x = float.Parse(_itemsPosition[0]);
                    RoomPresset.ItemsPosition[j].y = float.Parse(_itemsPosition[1]);
                }

                // WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                RoomPresset.ItemsRotation = new int[RoomPresset.ItemsInRoom];
                string[] _itemsRotationSeparation = row[7].Split(comaDelim, System.StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < RoomPresset.ItemsInRoom; j++)
                {
                    int.TryParse(_itemsRotationSeparation[j], out RoomPresset.ItemsRotation[j]);
                }

                RoomPresset.RoomPassword = row[8];
                GameController.RoomPressetList.Add(RoomPresset);
            }
        }

        public List<GameObject> GameItems(string _arrayNum)
        {
            switch (_arrayNum)
            {
                case "1":
                    return GameController.GetRayItem;
                case "2":
                    return GameController.GetMirrorItem;
                case "3":
                    return GameController.GetCombineItem;
                case "4":
                    return GameController.GetWallItem;
                case "5":
                    return GameController.GetFinishItem;
                case "6":
                    return GameController.GetOrbItem;
                case "7":
                    return GameController.GetBlockItem;
                case "8":
                    return GameController.GetInteractableItem;
                default:
                    return null;
            }
        }

        [SerializeField] private GameController GameController = null;
    }
}