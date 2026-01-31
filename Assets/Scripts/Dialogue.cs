using UnityEngine;
using DialogueEditor;

public class Dialogue : MonoBehaviour
{
    public NPCConversation _conversation;

    public Pause _pauseScript;

    private void OnTriggerEnter(Collider other)
    {
        ConversationManager.Instance.StartConversation(_conversation);
        _pauseScript._canPause = false;
    }

    private void OnTriggerExit(Collider other)
    {
        ConversationManager.Instance.EndConversation();
        _pauseScript._canPause = true;
    }
}
