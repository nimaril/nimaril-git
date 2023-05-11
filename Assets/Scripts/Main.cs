using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    bool isMute = false;
    public Material[] mats;
    public GameObject car;
    public float tasksCreationRate = 2f;  // MAKE LONGER!!!
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

    public void Start()
    {
        int carColor = PlayerPrefs.GetInt("CarColor", 0);
        car.GetComponent<MeshRenderer>().material = mats[carColor];
        StartCoroutine(CreateTask());
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
        QuestResults[5].SetActive(true);
        QuestResultsGO.SetActive(true);
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
    }
}
