using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class CoronaUI : MonoBehaviour {

    public static CoronaUI coronas;

    //public Text countryName;
    //public Text countryTemperature;
    //public Text countryLatitude, countryLongitude;
    //public Text countryCode;
    //public Text countrySunrise;
    //public Text countrySunset;
    //public Text countryWeatherDescription;
    //public Text countryHumidity;


    public TextMeshProUGUI active;
    public TextMeshProUGUI cured;
    public TextMeshProUGUI death;
    public TextMeshProUGUI total;
    public TextMeshProUGUI name;
    

    void Awake()
    {
       
        coronas = this;
        
    }
    




}
