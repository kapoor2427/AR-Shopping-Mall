using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject itemMainMenu;
    [SerializeField] private GameObject descriptionMenu;

    public void Description()
    {
        itemMainMenu.SetActive(false);
        descriptionMenu.SetActive(true);
    }
   
}
