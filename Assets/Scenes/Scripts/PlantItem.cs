using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    void Start()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyprice;
        icon.sprite = plant.icon;
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
    }
}
