using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRunning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text timerText;

    private float timer;

    private bool timeStarted;

    // Update is called once per frame
    void Awake()
    {
        timeStarted = true;
    }

    void Update()
    {
        if(timeStarted){
             timer += Time.deltaTime;
        }
        StartCoroutine(StartTime());
        
    }

    IEnumerator StartTime()
    {
        while (timeStarted)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = niceTime;

             Debug.Log("OnGUI  StartTime " + niceTime + "  timer  " + timer);
            yield return new WaitForSeconds(2);
        }
    }


}
