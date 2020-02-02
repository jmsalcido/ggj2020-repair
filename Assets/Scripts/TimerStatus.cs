using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerStatus : MonoBehaviour
{
    public Text timerValueText;
    public GameObject healthGameObject;
    public int timeValue;
    private Health _health;
    private int _countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        _health = healthGameObject.GetComponent<Health>();
        _countdownTimer = timeValue;
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    // Update is called once per frame
    void Update()
    {
        timerValueText.text = _countdownTimer.ToString();
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            if (_countdownTimer == 0)
            {
                _health.RemoveLive();
                _countdownTimer = timeValue;
            }
            yield return new WaitForSeconds(1);
            _countdownTimer--;
        }
    }
}