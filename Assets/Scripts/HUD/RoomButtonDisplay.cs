using UnityEngine;
using UnityEngine.UI;
using Core;

namespace HUD
{
    public class RoomButtonDisplay : MonoBehaviour
    {
        void Start()
        {
            RoomStars.text = RoomPresset.RoomStars.ToString();
            RoomName.text = RoomPresset.RoomName;
            UsserName.text = RoomPresset.UsserName;
        }

        public void SetRoomPressetToGameController()
        {
            GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            GameController.ButtonRoomPresset = RoomPresset;
        }

        public RoomPresset RoomPresset  = null;

        [SerializeField] private Text RoomStars = null;
        [SerializeField] private Text RoomName = null;
        [SerializeField] private Text UsserName = null;

        private GameController GameController = null;
    }
}
