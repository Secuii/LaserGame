using UnityEngine;

[CreateAssetMenu(fileName = "Room",menuName = "LaserGame/RoomPresset")]
public class RoomPresset : ScriptableObject
{
    public int RoomImage = 0;
    public int RoomStars = 0;
    public string RoomName = null;
    public string UsserName = null;
    public string RoomPassword = null;

    public float RoomHeigh;
    public float RoomWidth;

    public bool isPossibleToWin;

    public int ItemsInRoom;
    public GameObject[] ItemsRoom;
    public Vector2[] ItemsPosition;
    public int[] ItemsRotation;
}
