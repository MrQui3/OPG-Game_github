using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class DayNightCircl : MonoBehaviour
{

    public float time;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light Sun;
    public TextMeshProUGUI timerlabel;
    public int day;

    public float intensity;
    public Color fogday = Color.grey;
    public Color fognight = Color.black;

    public Trigger_m timer_trigger;
    public int timer15 = 900;
    private float stoptime = 0;
    public Grades_Label_Script gradelabel;
    public TextMeshProUGUI lefttime_label;
    public TextMeshProUGUI timetabel_label;
    public int tabeltabelchange = 0;
    private bool changeallowed = true;
    public Trigger_m ersteStundeTrigger;
    public Trigger_m erstePauseTrigger;
    public Trigger_m dritteStundeTrigger;
    public Trigger_m zweitePauseTrigger;
    public Trigger_m fünfteStungeTrigger;
    public Trigger_m MittagspauseTrigger;
    public Trigger_m siebteStundeTrigger;
    public Trigger_m SchuleAusTrigger;

    public int speed;

    void Start()
    {
        if (TreeManager.GetTreeManager() == null)
        {
            TreeManager.TreeManagerStarten();
        }
        Debug.Log("Hi, now i'm on, too");
        timer_trigger = new Trigger_m(5);
        TreeManager.GetTreeManager().addTrigger(timer_trigger);

        ersteStundeTrigger = new Trigger_m(12);
        TreeManager.GetTreeManager().addTrigger(ersteStundeTrigger);

        erstePauseTrigger = new Trigger_m(13);
        TreeManager.GetTreeManager().addTrigger(erstePauseTrigger);

        dritteStundeTrigger = new Trigger_m(14);
        TreeManager.GetTreeManager().addTrigger(dritteStundeTrigger);

        zweitePauseTrigger = new Trigger_m(15);
        TreeManager.GetTreeManager().addTrigger(zweitePauseTrigger);

        fünfteStungeTrigger = new Trigger_m(16);
        TreeManager.GetTreeManager().addTrigger(fünfteStungeTrigger);

        MittagspauseTrigger = new Trigger_m(17);
        TreeManager.GetTreeManager().addTrigger(MittagspauseTrigger);

        siebteStundeTrigger = new Trigger_m(18);
        TreeManager.GetTreeManager().addTrigger(siebteStundeTrigger);

        SchuleAusTrigger = new Trigger_m(19);
        TreeManager.GetTreeManager().addTrigger(SchuleAusTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTime();
        
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            day += 1;
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds(time);
        string[] temptim = new string[2];
        temptim = currentTime.ToString().Split(':');
        timerlabel.text = temptim[0] + ":" + temptim[1]+ " Uhr";


        if (temptim[0] == "08" && temptim[1] == "00")
        {
            timetabel_label.text = "1-2 Stunde";
            if (changeallowed == true)
            {
                tabeltabelchange = 1;
                speed = speed + speed ;
                ersteStundeTrigger.triggered();
                changeallowed = false;

            }
        }
        else if (temptim[0] == "09" && temptim[1] == "30")
        {
            timetabel_label.text = "1. Pause";
            if (changeallowed == true)
            {
                tabeltabelchange = 2;
                speed = speed - speed / 2;
                erstePauseTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "09" && temptim[1] == "45")
        {
            timetabel_label.text = "3-4 Stunde";
            if (changeallowed == true)
            {
                tabeltabelchange = 3;
                speed = speed + speed;
                dritteStundeTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "11" && temptim[1] == "15")
        {
            timetabel_label.text = "2. Pause";
            if (changeallowed == true)
            {
                tabeltabelchange = 4;
                speed = speed - speed / 2;
                zweitePauseTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "11" && temptim[1] == "30")
        {
            timetabel_label.text = "5-6 Stunde";
            if (changeallowed == true)
            {
                tabeltabelchange = 5;
                speed = speed + speed;
                fünfteStungeTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "13" && temptim[1] == "00")
        {
            timetabel_label.text = "Mittagspause";
            if (changeallowed == true)
            {
                tabeltabelchange = 6;
                speed = speed - speed / 2;
                MittagspauseTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "13" && temptim[1] == "45")
        {
            timetabel_label.text = "7-8 Stunde";
            if (changeallowed == true)
            {
                tabeltabelchange = 7;
                speed = speed + speed;
                siebteStundeTrigger.triggered();
                changeallowed = false;
            }
        }
        else if (temptim[0] == "15" && temptim[1] == "15")
        {
            timetabel_label.text = "Schultag Ende";
            if (changeallowed == true)
            {
                tabeltabelchange = 8;
                speed = speed - speed / 2;
                SchuleAusTrigger.triggered();
                changeallowed = false;
            }
        }
        else
        {
            if (changeallowed == false)
            {
                changeallowed = true;
            }
        }

        SunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - (time - 43200) / 43200;
        }
        RenderSettings.fogColor = Color.Lerp(fogday, fognight, intensity * intensity);

        Sun.intensity = intensity;

        if (timer_trigger.aktiv)
        {
            lefttime_label.alpha = 1f;
            currentTime = TimeSpan.FromSeconds(timer15-stoptime);
            string[] temptim2 = new string[2];

            temptim2 = currentTime.ToString().Split(':');
            lefttime_label.text = temptim2[0] + ":" + temptim2[1] + " Uhr";
            stoptime += Time.deltaTime * speed;
            if (stoptime >= timer15)
            {
                gradelabel.ChangeGrade(0.2f);
                stoptime = 0;
                timer_trigger.triggered();
            }
        }
        else
        {
            lefttime_label.alpha = 0f;
            stoptime = 0;
        }
        
    }
}
