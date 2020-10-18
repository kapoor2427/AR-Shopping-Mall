using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RegisterApiCall : MonoBehaviour
{
    // Defining Inputfield
    [SerializeField] private InputField username;
    [SerializeField] private InputField password;
    [SerializeField] private InputField firstName;
    [SerializeField] private InputField lastName;

    //Initializing Panels
    public GameObject MainMenu;
    public GameObject RegisterPanel;

    //Register Authentication
    public void Register()
    {
        StartCoroutine(UploadRegisterData());
    }

    //Register Panel
    public void RegisterScreen()
    {
        MainMenu.SetActive(false);
        RegisterPanel.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        RegisterPanel.SetActive(false);
    }

    // Register Functionality
    IEnumerator UploadRegisterData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text.ToString());
        form.AddField("password", password.text.ToString());
        form.AddField("firstName", firstName.text.ToString());
        form.AddField("lastName", lastName.text.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:4000/users/register", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(result);
                Debug.Log("Form upload complete!");
            }
        }
    }
}
