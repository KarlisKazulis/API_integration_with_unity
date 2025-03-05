using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public APIClient apiClient;
    public TextMeshProUGUI apiResponseText;

    void Start()
    {
        if (apiClient == null)
        {
            apiClient = FindFirstObjectByType<APIClient>();
        }

        apiClient.GetUser(1);
        apiClient.GetUserPosts(1);
    }

    public void DisplayUserInfo(string userInfo)
    {
        apiResponseText.text = "User:\n" + userInfo;
    }

    public void DisplayUserPosts(string postsInfo)
    {
        apiResponseText.text += "\nUser Posts:\n" + postsInfo;
    }
}
