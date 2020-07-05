using UnityEngine;
using System.Collections;
using Core;

namespace Room
{
    public class RoomSetup : MonoBehaviour
    {
        //TODO CREACION DE LA SALA

        //TODO INSTANCIAR OBJETOS
        //TODO COLOCAR ROTACIONES
        //TODO COLOCAR POSICIONES


        public void SetGameMapSize()
        {
            MapSize.size = new Vector2(GameController.CreatorRoomPresset.RoomWidth, GameController.CreatorRoomPresset.RoomHeigh);
            MapSizeCollider.size = new Vector3(GameController.CreatorRoomPresset.RoomWidth, GameController.CreatorRoomPresset.RoomHeigh, 0.2f);
        }

        [SerializeField] private SpriteRenderer MapSize = null;
        [SerializeField] private BoxCollider MapSizeCollider = null;



        [SerializeField] private GameController GameController = null;
    }
}