using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    private string baseUrl = "http://127.0.0.1:5000/";  

    public DisplayText displayText;  

    void Start()
    {
        if (displayText == null)
        {
            displayText = FindFirstObjectByType<DisplayText>();
        }

        GetUser(1);
        GetUserPosts(1);
    }

    public void GetUser(int userId)
    {
        string url = baseUrl + "users/" + userId;

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest();

        while (!request.isDone)
        {
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            string userData = request.downloadHandler.text;
            Debug.Log("User Data: " + userData);
            displayText.DisplayUserInfo(userData);  
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    public void GetUserPosts(int userId)
    {
        string url = baseUrl + "users/" + userId + "/posts";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest();

        while (!request.isDone)
        {
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            string postsData = request.downloadHandler.text;
            Debug.Log("Posts Data: " + postsData);
            displayText.DisplayUserPosts(postsData);  
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
}
