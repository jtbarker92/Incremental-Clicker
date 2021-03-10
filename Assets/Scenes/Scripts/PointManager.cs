using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private int pointsPerClick = 1;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text upgradeText;

    //updates
    private int costToUpdate = 5;
    public void Update()
    {u
        UpdateUpgradeText();
    }

    public void AddPoints()
    {
        points+= pointsPerClick;
        pointsText.text = points.ToString();
    }

    public void UpgradedPointsPerClick()
    {
        if (points >= costToUpdate)
        {
            points -= costToUpdate;
            pointsPerClick++;
            costToUpdate = costToUpdate * 2;
            UpdatePointsText();
            UpdateUpgradeText();
        }
        
    }
    private void UpdateUpgradeText()
    {
        if(upgradeText != null)
        {
            upgradeText.text = "Upgrade " + costToUpdate.ToString();
        }
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
            
    }

   

    
}
