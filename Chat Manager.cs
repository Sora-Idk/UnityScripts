using UnityEngine;
using UnityEngine.UI;


//In hierarchy add the following canvas>empty[Chat Manager]>image>Name,Message
//name and message is text object use the anchors in unity to place them over the image(chatbubble)
//add this script to empty and use ChatBubbleManager.Instance.<FunctionToCall>(); in any script
public class ChatManager : MonoBehaviour
{
    public GameObject ChatBubble;
    private Text message_;
    private Text name_;

    // to make public func accessible from anywhere
    private static ChatBubbleManager instance;
    public static ChatBubbleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ChatBubbleManager>();
            }
            return instance;
        }
    }

    /// <summary>
    /// Displays a chatbox on screen with message provided
    /// </summary>
    /// <param name="NPCname">Name of NPC/Name to be displayed</param>
    /// <param name="message">Message to be displayed put null if you want to make the message box go away</param>
    public void Talk(string NPCname, string message = null)
    {
        if (message != null)
        {
            ChatBubble.SetActive(true);
            name_.text = NPCname;
            message_.text = message;
        }      
        if (message == null) 
        {
            ChatBubble?.SetActive(false);
        }
    }

    private void Start()
    {
        ChatBubble.SetActive(false);
        message_ = ChatBubble.transform.Find("Message")?.GetComponent<Text>();
        name_ = ChatBubble.transform.Find("Name")?.GetComponent<Text>();
    }
}
