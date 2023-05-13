using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    bool isMute = false;
    public Material[] mats;
    public GameObject car;
    public float tasksCreationRate = 4f;  // MAKE LONGER!!!
    public bool hasTask = false;
    public bool isTaskTaken = false;
    public int task = 0;
    public GameObject QuestsGO;
    public GameObject[] Quests;
    public GameObject QuestIcon;
    public GameObject QuestResultsGO;
    public GameObject[] QuestResults;
    public GameObject[] Packages;
    public bool isPackageTaken = false;
    public GameObject timerGO;
    public GameObject moneyGO;
    private IEnumerator _timerCoroutine;
    private int _timer;
    public Action OnTimeOut;
    public int[] moneyRewards = { 25, 25, 20, 15, 10 };

    public void Start()
    {
        int carColor = PlayerPrefs.GetInt("CarColor", 0);
        car.GetComponent<MeshRenderer>().material = mats[carColor];
        StartCoroutine(CreateTask());
        
        int money = PlayerPrefs.GetInt("Money", 0);
        moneyGO.GetComponent<TMP_Text>().text = money.ToString();
        isPackageTaken = false;
    }

    private void SetTimeText(int seconds)
    {
        timerGO.GetComponent<TMP_Text>().text = (_timer / 60).ToString() + ':' + (_timer % 60).ToString();
    }
    
    private void StartTimer(int totalTime, Action timeOut)
    {
        OnTimeOut = timeOut;
        //reset the timer at the start
        _timer = totalTime;
        _timerCoroutine = StartTimer(totalTime);
        StartCoroutine(_timerCoroutine);
    }
    
    public void StopTimer()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
            OnTimeOut = null;
        }
    }
    
    private void TimeOut()
    {
        ShowFailure();
    }
    
    private IEnumerator StartTimer(int totalTime)
    {
        while (_timer > 0)
        {
            //waiting 1 second in real time and decreasing the timer value
            yield return new WaitForSecondsRealtime(1);
            _timer--;
            SetTimeText(_timer);
            Debug.Log("Timer is : " + _timer);
        }

        //trigger the timeout action to inform that the time is up.
        OnTimeOut?.Invoke();
    }

    
    public void LoadSettings()
    {
        Debug.Log("Settings");
        SceneManager.LoadScene(3);
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        Debug.Log(AudioListener.volume);
    }

    private IEnumerator CreateTask()
    {
        if (hasTask)
        {
            yield break;
        } 
        yield return new WaitForSeconds(tasksCreationRate);
        hasTask = true;

        CreateRandomTask();
    }

    public void CreateRandomTask()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            Quests[i].SetActive(false);
        }
        task = UnityEngine.Random.Range(0, Quests.Length);
        Quests[task].SetActive(true);
        QuestIcon.SetActive(true);
    }

    public void AcceptTask()
    {
        isTaskTaken = true;
        Quests[task].transform.GetChild(1).gameObject.SetActive(false);
        Quests[task].transform.GetChild(5).gameObject.SetActive(false);
        Quests[task].transform.GetChild(6).gameObject.SetActive(false);
        CloseTask();
        Packages[task].SetActive(true);
        StartTimer(61, TimeOut);
    }

    public void RefuseTask()
    {
        QuestIcon.SetActive(false);
        hasTask = false;
        StartCoroutine(CreateTask());
        CloseTask();
    }

    public void ShowTask()
    {
        QuestsGO.SetActive(true);
    }

    public void CloseTask()
    {
        QuestsGO.SetActive(false);
    }

    public void ShowReward()
    {
        QuestResults[task].SetActive(true);
        QuestResultsGO.SetActive(true);
    }

    public void ShowFailure()
    {
        QuestResults[5].SetActive(true);
        QuestResultsGO.SetActive(true);
    }

    public void CloseFailure()
    {
        QuestResults[5].SetActive(false);
        QuestResultsGO.SetActive(false);
        QuestIcon.SetActive(false);
        StartCoroutine(CreateTask());
    }
    
    public void CloseReward()
    {
        Quests[task].transform.GetChild(1).gameObject.SetActive(true);
        Quests[task].transform.GetChild(5).gameObject.SetActive(true);
        Quests[task].transform.GetChild(6).gameObject.SetActive(true);
        QuestResultsGO.SetActive(false);
        QuestResults[task].SetActive(false);
        StartCoroutine(CreateTask());
        int money = PlayerPrefs.GetInt("Money", 0);
        money += moneyRewards[task];
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
        moneyGO.GetComponent<TMP_Text>().text = money.ToString();
    }
}
