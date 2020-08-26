using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            ImportRoomPresset.CreatePressetsFromFile();
            ButtonInteraction.CreateButtons();
            TemporalList.AddRange(RoomPressetList);
        }

        [Header("Items prefab")]
        [SerializeField] private List<GameObject> RayItems = new List<GameObject>();
        public List<GameObject> GetRayItem { get => RayItems; }

        [SerializeField] private List<GameObject> MirrorItems = null;
        public List<GameObject> GetMirrorItem { get => MirrorItems; }

        [SerializeField] private List<GameObject> CombineItems = null;
        public List<GameObject> GetCombineItem { get => CombineItems; }

        [SerializeField] private List<GameObject> WallItems = null;
        public List<GameObject> GetWallItem { get => WallItems; }

        [SerializeField] private List<GameObject> FinishItems = null;
        public List<GameObject> GetFinishItem { get => FinishItems; }

        [SerializeField] private List<GameObject> OrbItem = null;
        public List<GameObject> GetOrbItem { get => OrbItem; }

        [SerializeField] private List<GameObject> BlockItem = null;
        public List<GameObject> GetBlockItem { get => BlockItem; }

        [SerializeField] private List<GameObject> LaserItem = null;
        public List<GameObject> GetLaserItem { get => LaserItem; }

        [SerializeField] private List<GameObject> InteractableItem = null;
        public List<GameObject> GetInteractableItem { get => InteractableItem; }


        [SerializeField] private ImportRoomPressets ImportRoomPresset = null;
        [SerializeField] private ButtonCreation ButtonInteraction = null;

        [SerializeField] private GameObject RoomButtonPrefab = null;
        public GameObject RoomButtonPrefabs { get => RoomButtonPrefab; }

        public List<RoomPresset> RoomPressetList = new List<RoomPresset>();
        public List<RoomPresset> TemporalList = new List<RoomPresset>();

        //NEW ROOM FROM CREATOR MODE
        public RoomPresset CreatorRoomPresset { get; set; } = null;
        //ROOM FROM BUTTONS
        public RoomPresset ButtonRoomPresset= null;

        public string UsserID { get; set; } = null;
        public int UsserLevel { get; set; } = 0;
        public int UsserExperience { get; set; } = 0;
    }
}