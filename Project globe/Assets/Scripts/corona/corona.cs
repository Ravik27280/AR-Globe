
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public enum UnitTypes
{
    metric,imperial
}

public class corona : MonoBehaviour {


    //imperial
    //metric
    
    
    public UnitTypes CoronaUnityType;
    public string StateName;
    public GameObject InputField;
    [SerializeField]
    //private string API_KEY = "15d8db955e53953ebd82859586b3db56";
   
  



    public void store()
    {
        StateName = InputField.GetComponent<Text>().text;
        //StateName = InputField.GetComponent<Text>().text;
        GET("http://covid19-india-adhikansh.herokuapp.com/state/" + StateName);
    }
    // Use this for initialization
    //void Start () {

      //  GET("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&modejson&units=" + weatherUnityType.ToString() + "&APPID=" + API_KEY);
    //}
 
    // GET JSON Response
    public Example GET(string url)
    {
        Example model = new Example();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                model = JsonConvert.DeserializeObject<Example>(reader.ReadToEnd());
                CoronaUI.coronas.active.text = string.Format("Active Cases : {0} ", model.data[0].active);
               // CoronaUI.coronas.countryTemperature.text = CoronaUnityType == UnitTypes.imperial ? string.Format("Country Temperature is: {0} °F", model.main.temp.ToString()) :
                 //    string.Format("Country Temperature is: {0} °C", model.main.temp.ToString());
                CoronaUI.coronas.cured.text = string.Format("Recovery : {0}", model.data[0].cured);
                CoronaUI.coronas.death.text = string.Format("No. of Deaths {0} ", model.data[0].death);
                CoronaUI.coronas.total.text = string.Format("Total cases : {0} ", model.data[0].total);
                CoronaUI.coronas.name.text = string.Format("State Name : {0}", model.data[0].name);


                //CoronaUI.coronas.countrySunset.text = string.Format("Country Sunset: {0}", UnixTimeStampToDateTime(model.sys.sunset));

                //CoronaUI.coronas.countryWeatherDescription.text = string.Format("Country Sky Status: {0} ", model.weather[0].description);

                //CoronaUI.coronas.countryHumidity.text = string.Format("Country Humidity: {0}% ", model.main.humidity);



              


            }

        }
        catch (WebException ex)
        {
            WebResponse errorResponse = ex.Response;
            using (Stream responseStream = errorResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                string errorText = reader.ReadToEnd();
                // log errorText
            }
            throw;
        }

        return model;
    }


    // Helpers
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
   
   
}



// Open Corona Map JSON Response
public class Datum
{
    public string _id { get; set; }
    public int active { get; set; }
    public int cured { get; set; }
    public int death { get; set; }
    public int total { get; set; }
    public string name { get; set; }
}

public class Example
{
    public IList<Datum> data { get; set; }
}
