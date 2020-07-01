using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class FileTextEditor{
    public static string ReadFileText()
    {
        StreamReader fileData = new StreamReader(path);
        string fileText = fileData.ReadToEnd();
        fileData.Close();
        return fileText;
    }

    public static void EditRoomFile(List<RoomPresset> _fileText)
    {
        StringBuilder csvContent = new StringBuilder();
        StringBuilder itemsInRoom = new StringBuilder();
        StringBuilder itemsPosition = new StringBuilder();
        StringBuilder itemsRotation = new StringBuilder();

        for (int i = 0; i < _fileText.Count; i++)
        {
            for (int j = 0; j < _fileText[i].ItemsInRoom; j++)
            {
                itemsInRoom.Append(_fileText[i].ItemsInRoom.ToString());
                itemsPosition.Append(Mathf.Round(_fileText[i].ItemsPosition[j].x).ToString() + "," + Mathf.Round(_fileText[i].ItemsPosition[j].y).ToString()) ;
                itemsRotation.Append(_fileText[i].ItemsRotation[j].ToString());
                if(j < _fileText[i].ItemsInRoom- 1)
                {
                    itemsInRoom.Append("-");
                    itemsPosition.Append("-");
                    itemsRotation.Append("-");
                }
            }
            csvContent.Append(_fileText[i].RoomImage.ToString() + ";" + _fileText[i].RoomStars.ToString() + ";" + _fileText[i].RoomName + ";" + _fileText[i].UsserName + ";" +
                                _fileText[i].ItemsInRoom.ToString() + ";" + itemsInRoom + ";" + itemsPosition + ";" + itemsRotation + ";" + _fileText[i].RoomPassword + ";");
            if(i < _fileText.Count - 1)
            {
                csvContent.Append("\n");
            }
            itemsInRoom.Clear();
            itemsPosition.Clear();
            itemsRotation.Clear();
        }

        File.Delete(path);
        File.AppendAllText(path, csvContent.ToString());
    }


    private static string path = Application.persistentDataPath + "/GameRooms.csv";
}
