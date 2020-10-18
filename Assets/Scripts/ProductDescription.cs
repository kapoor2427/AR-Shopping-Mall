using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class Values
//{
//    public string g_name;
//    public string g_description;
//    public int g_price;
//}

public class ProductDescription : MonoBehaviour
{
    private GameObject name;
    private string productId;
    public string url;
    private string productName;
    private int quantity = 0;
    private double price;

    void Start()
    {
        productId = name.name;
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(ProductData(url+"/products/"+productId));
    }

    public IEnumerator ProductData(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    print(result);
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }

    public void AddToCart()
    {
        quantity += 1;
        StartCoroutine(CartData(url + "/orders/"));
    }

    public IEnumerator CartData(string v)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", productName);
        form.AddField("quantity", quantity);
        form.AddField("price", price.ToString());
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
                print(result);
                Debug.Log("Product Added to Cart");
            }
        }
    }
}
