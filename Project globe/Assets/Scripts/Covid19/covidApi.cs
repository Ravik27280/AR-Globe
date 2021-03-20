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



public enum UnitT
{
    metric, imperial
}

public class covidApi : MonoBehaviour
{
  


    //imperial
    //metric

    public UnitT CovidType;
    public int a;
    public TMP_InputField input;
    public int[] b = new int[10];
    //public string cityName;
    //public GameObject InputField;
    [SerializeField]
    //private string API_KEY = "15d8db955e53953ebd82859586b3db56";
      void Update()
    {
        //cityName = InputField.GetComponent<Text>().text;
        GET("https://api.rootnet.in/covid19-in/stats/latest"); //+ cityName + "&modejson&units=" + weatherUnityType.ToString() + "&APPID=" + API_KEY);
    }

    public void calling()
    {
       a= int.Parse(input.text);
    }
    public RootObject GET(string url)
    {
        RootObject model = new RootObject();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
               
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                model = JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd());
                CovidUI.Covidui.TotalConform.text = string.Format("Total Conformed cases- {0}", model.data.summary.total);
                CovidUI.Covidui.Totaldeaths.text = string.Format("Total Deaths- {0}", model.data.summary.deaths);
                CovidUI.Covidui.discharged.text = string.Format("Total Discharged- {0}", model.data.summary.discharged);

                CovidUI.Covidui.Location.text = string.Format("Location- {0}", model.data.regional[a].loc);
                CovidUI.Covidui.regionalDeath.text = string.Format("Deaths- {0}", model.data.regional[a].deaths);
                CovidUI.Covidui.regionalIndiaConf.text = string.Format("Total Indians- {0}", model.data.regional[a].confirmedCasesIndian);
                CovidUI.Covidui.regionalForenConf.text = string.Format("Total Foredign- {0}", model.data.regional[a].confirmedCasesForeign);
                CovidUI.Covidui.regionalDischarged.text = string.Format("Discharged- {0}", model.data.regional[a].discharged);
            
             



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
 


}