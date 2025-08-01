using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class Room : MonoBehaviour
{
    public TMP_Text Name;
    public void JoinRoom()
    {
        GameObject.Find("CreateAndJoin").GetComponent<CreateAndJoin>().JoinRoomList(Name.text);
    }

}
