using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] private int points; // Int storing current points. Points function as both a score & currency for upgrades as well as allowing different upgrades to become available at certain breakpoints.
    [SerializeField] private int pointsPerClick = 1; // Int storing the amount of points gained per click.
    [SerializeField] private Text pointsText; // Text representing the current points value.
    [SerializeField] private Text upgradeText; // Text representing the current cost of upgrading.
    [SerializeField] private int pointPerSecond = 0; // int used to increase the points gained per second after upgrading.
    [SerializeField] private float timer; // Float used to incrementally increase points over time after upgrading.
    [SerializeField] private int costToUpdate = 5; // Int storing the point cost of each update breakpoint.


    public void Update()
    {
        //Increases points by int pointPerSecond as it is upgraded.
        //It runs constantly but is only activated once upgrading which adds PointPerSecond each second to points as it is initially set to 0.
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1;
            points += pointPerSecond;
        }

        // Updates the point text, becomes required once the points start increasing per second after the pointPerSecond upgrade.
        pointsText.text = points.ToString();

    }

    //Increases points value by pointsPerClick value once the button is pressed in game.
    public void AddPoints()
    {
        points += pointsPerClick;
        pointsText.text = points.ToString();
    }


    //Increases points gained per click by 1 per upgrade.
    //Deducts points by the current upgrade cost.
    //Increases current upgrade cost by 2X.
    //Updates the point text and upgrade cost text
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

    //Updates the upgrade cost text when called by upgrades
    private void UpdateUpgradeText()
    {
        if (upgradeText != null)
        {
            upgradeText.text = " Upgrade Cost = " + costToUpdate.ToString();
        }
    }


    //Increases points gained per click by 10 per upgrade.
    //Deducts points by the current upgrade cost.
    //Increases current upgrade cost by 2X.
    //Updates the point text and upgrade cost text
    //Requires an upgrade cost of at least 160 to upgrade
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

    //Increases points gained per click and points per second by 2x per upgrade.
    //Deducts points by the current upgrade cost.
    //Increases current upgrade cost by 3X.
    //Updates the point text and upgrade cost text
    //Requires an upgrade cost of at least 2560 to upgrade
    public void UpgradedPointsPerClick3()
    {
        if (points >= costToUpdate && costToUpdate >= 2560)
        {
            points -= costToUpdate;
            pointsPerClick = pointsPerClick * 2;
            costToUpdate = costToUpdate * 3;
            UpdatePointsText();
            UpdateUpgradeText();
            pointPerSecond = pointPerSecond * 2;
        }

    }

    //Increases points gained per second by 1 per upgrade.
    //Deducts points by the current upgrade cost.
    //Increases current upgrade cost by 2X.
    //Updates the point text and upgrade cost text
    //Requires an upgrade cost of at least 160 to upgrade
    public void UpgradedPointsPerClick4()
    {
        if (points >= costToUpdate && costToUpdate >= 160)
        {
            points -= costToUpdate;
            costToUpdate = costToUpdate * 3;
            UpdatePointsText();
            UpdateUpgradeText();
            pointPerSecond++;
        }

    }


    // Updates the points score once called by the Upgrade functions
    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();

    }
   

}