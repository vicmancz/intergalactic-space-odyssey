using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDGame : MonoBehaviour
{
    private float timeRemaining = 60;
    public Text countdown;
    public Text lifeNumber;

    // Start is called before the first frame update
    void Start()
    {
        countdown.text = Math.Round(timeRemaining).ToString();
        lifeNumber.text = Player.lifes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        countdown.text = Math.Round(timeRemaining).ToString();
        lifeNumber.text = Player.lifes.ToString();
    }
}