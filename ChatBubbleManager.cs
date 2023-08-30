using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChatBubbleManager : MonoBehaviour
{
    public GameObject ChatBubble;
    private Text text;
    private new Text name;

    private void Start()
    {
        ChatBubble.SetActive(false);
        text = ChatBubble.transform.Find("Message")?.GetComponent<Text>();
        name = ChatBubble.transform.Find("Name")?.GetComponent<Text>();
    }

    public void Talk(string message, string NPCname)
    {
        if (text != null)
        {
            ChatBubble.SetActive(true);
            name.text = NPCname;
            text.text = message;
        }      
    }
    public void Hide() { 
        ChatBubble?.SetActive(false);
    }
}
