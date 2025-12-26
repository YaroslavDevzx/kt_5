
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image[] stars;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Button button;


    [SerializeField] private GameObject lockedPanel;
    [SerializeField] private GameObject starsHolder;

    [Header("Sprites")]
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite unlockedSprite;


    public void Init(int id, int starsCount, bool isLocked)
    {
        levelText.text = (id + 1).ToString();
        UpdateUI(isLocked, starsCount);
    }

    void UpdateUI(bool isLocked, int starsCount)
    {
        foreach (var star in stars)
        {
            star.gameObject.SetActive(!isLocked);
        }
        button.interactable = !isLocked;
        starsHolder.SetActive(!isLocked);
        lockedPanel.SetActive(isLocked);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = (i < starsCount) ? unlockedSprite : lockedSprite;
        }
    }
}
