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
    [SerializeField] private float pointsPerSecond;
    [SerializeField] private float scoreConverter;


    private int costToUpdate = 5;

    public void Start()
    {
        pointsPerSecond = 10;
    }
    public void Update()
    {
        UpdateUpgradeText();


    }

    public void PointsPerSecondUpgrade()
    {
        scoreConverter += pointsPerSecond * Time.deltaTime;
        pointsPerSecond += Mathf.RoundToInt(scoreConverter);

    } 

    public void AddPoints()
    {
        points += pointsPerClick;
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
        if (upgradeText != null)
        {
            upgradeText.text = " Upgrade Cost = " + costToUpdate.ToString();
        }
    }

    public void UpgradedPointsPerClick2()
    {
        if (points >= costToUpdate && costToUpdate >= 160)
        {
            points -= costToUpdate;
            pointsPerClick = pointsPerClick + 10;
            costToUpdate = costToUpdate * 2;
            UpdatePointsText();
            UpdateUpgradeText();
        }

    }

    public void UpgradedPointsPerClick3()
    {
        if (points >= costToUpdate && costToUpdate >= 2560)
        {
            points -= costToUpdate;
            pointsPerClick = pointsPerClick * 2;
            costToUpdate = costToUpdate * 3;
            UpdatePointsText();
            UpdateUpgradeText();
        }

    }

    public void UpgradedPointsPerClick4()
    {
        if (points >= costToUpdate && costToUpdate >= 10)
        {
            points -= costToUpdate;
            pointsPerSecond = 30;
            costToUpdate = costToUpdate * 3;
            UpdatePointsText();
            UpdateUpgradeText();
        }

    }


    // Updates the points score once called by the Upgrade functions
    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();

    }

}