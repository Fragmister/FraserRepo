using UnityEngine;
using TMPro;
using NUnit.Framework.Constraints;

public class TabManager : MonoBehaviour
{


   


    public GameObject tabs;
    public void Buttonclick()
    {
        Debug.Log("Button Click");

        tabs.SetActive(!tabs.activeInHierarchy);
    }

}
