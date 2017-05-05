using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : Singleton<CountdownTimer>
{
    public Text CountdownText;

    public int CountdownTime;

    public delegate void OnTimerDone();
    public event OnTimerDone TimerDone;

  


    // Use this for initialization
    void Start()
    {
        SetTextNumber(CountdownTime);
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetTextNumber(int number)
    {
        CountdownText.text = number.ToString();
    }

    private IEnumerator Countdown()
    {
        var timer = CountdownTime;
        while (timer > 0)
        {
            SetTextNumber(timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }
        CountdownText.gameObject.SetActive(false);
        if (TimerDone != null) TimerDone();
    }
}
