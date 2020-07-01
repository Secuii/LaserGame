using UnityEngine;
using UnityEngine.UI;
using Core;

namespace Room
{
    public class RoomScriptableCreator : MonoBehaviour
    {
        public void CreateInstanceScriptable()
        {
            RoomPresset RoomPresset = ScriptableObject.CreateInstance<RoomPresset>();
            RoomPresset.RoomName = RoomName.text;
            RoomPresset.RoomPassword = RoomPassword.text;
            RoomPresset.UsserName = GameController.UsserID;
            RoomPresset.RoomWidth = ConvertSizeRoom(Mathf.RoundToInt(RoomWidth.value));
            RoomPresset.RoomHeigh = ConvertSizeRoom(Mathf.RoundToInt(RoomHeigh.value));
            GameController.CreatorRoomPresset = RoomPresset;
        }

        public float ConvertSizeRoom(int _size)
        {
            switch (_size)
            {
                case 1: return 0.72f;
                case 2: return 1.12f;
                case 3: return 1.52f;
                case 4: return 1.92f;
                case 5: return 2.32f;
                case 6: return 2.72f;
                default: return 0f;
            }
        }

        [SerializeField] private InputField RoomName = null;
        [SerializeField] private Slider RoomHeigh = null;
        [SerializeField] private Slider RoomWidth = null;
        [SerializeField] private InputField RoomPassword = null;



        [SerializeField] private GameController GameController = null;
    }
}