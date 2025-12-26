using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private int lockedLevelsCount = 5;
    [Space(5)]
    [SerializeField] private Transform levelsGrid;
    [SerializeField] private GameObject levelPrefab;

    [Space(15)]
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject playPanel;

    [SerializeField] private Button playButton;
    [SerializeField] private Button returnButton;

    void Start()
    {
        playButton.onClick.AddListener(ShowLevelsPanel);
        returnButton.onClick.AddListener(ShowPlayPanel);
    }

    void ShowPlayPanel()
    {
        levelsPanel.SetActive(false);
        playPanel.SetActive(true);
    }

    void ShowLevelsPanel()
    {
        playPanel.SetActive(false);
        levelsPanel.SetActive(true);
        ShowLevels();
    }

    void ShowLevels()
    {
        foreach (Transform child in levelsGrid)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < levels.Count; i++)
        {
            bool isLocked = levels[i].isLocked;
            isLocked = i >= lockedLevelsCount && i != 0;

            GameObject levelObj = Instantiate(levelPrefab, levelsGrid);
            LevelButton levelButton = levelObj.GetComponent<LevelButton>();
            levelButton.Init(i, levels[i].Stars, isLocked);
        }
    }

}

[Serializable]
public class Level
{
    [Range(0,3)] public int Stars = 0;
    public bool isLocked = true;
}