using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginApiCall : MonoBehaviour
{
    //public string url;
    
    // Defining Inputfield parameters
    [SerializeField] private InputField username;
    [SerializeField] private InputField password;

    //Initializing Panels
    public GameObject MainMenu;
    public GameObject LoginPanel;

    //Login Authentication
    public void Authenticate()
    {
        StartCoroutine(UploadLoginData());
    }

    //Login Panel
    public void LoginScreen()
    {
        MainMenu.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        LoginPanel.SetActive(false);
    }


    //public IEnumerator Get(string url)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get(url))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            if (www.isDone)
    //            {
    //                // handle the result
    //                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //                Debug.Log(result);
    //            }
    //            else
    //            {
    //                //handle the problem
    //                Debug.Log("Error! data couldn't get.");
    //            }
    //        }
    //    }

    //}

    // Login Functionality
    IEnumerator UploadLoginData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text.ToString());
        form.AddField("password", password.text.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:4000/users/authenticate", form))
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
                Debug.Log("Login Successful!");
            }
        }
    }

}
