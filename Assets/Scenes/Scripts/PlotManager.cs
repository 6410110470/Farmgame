using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    int plantStage = 0;
    public PlantObject selectplant;
    float timer;
    SpriteRenderer Plot;
    bool isPreplot = false;
    public Sprite PrePlot;
    FarmManager fm;
    void Start()
    {
        Plot = GetComponent<SpriteRenderer>();
        fm = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectplant.plantStages.Length - 1) //Check จำนวนภาพ sprite
            {
                timer = selectplant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }

    }
    public void Water()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectplant.plantStages.Length - 1) //Check จำนวนภาพ sprite
            {
                timer = selectplant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (isPlanted && plantStage == selectplant.plantStages.Length -1)
        {
            Harvest();
        }
        else
        {
            if (isPreplot == true)
            {
                Plant(fm.selected_plant);
            }

        }
    }

    public void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }
    void Plant(PlantObject newPlant)
    {
        selectplant = newPlant;
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectplant.timeBtwStages;
        plant.gameObject.SetActive(true);

    }
    void UpdatePlant()
    {
        plant.sprite = selectplant.plantStages[plantStage];
    }
    private void OnMouseOver()
    {
        if (isPlanted)
        {
            Plot.color = Color.red;
        }
        else
        {
            Plot.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        Plot.color = Color.white;
    }
    public void ChangeSprite()
    {
        Plot.sprite = PrePlot;
        isPreplot = true;
    }

}