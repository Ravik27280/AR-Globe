using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class CovidUI : MonoBehaviour {

    public static CovidUI Covidui;

    public TMP_Text TotalConform;
    public TMP_Text Totaldeaths;
    public TMP_Text discharged;


    public TMP_Text Location;
    public TMP_Text regionalDeath;
    public TMP_Text regionalIndiaConf;
    public TMP_Text regionalForenConf;
    public TMP_Text regionalDischarged;
   
 


    
    void Awake()
    {

        Covidui = this;
        
    }
    




}
