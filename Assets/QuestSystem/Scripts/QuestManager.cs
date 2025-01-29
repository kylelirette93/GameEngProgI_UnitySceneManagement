using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // List of quest objects.
    public List<Quest> quests = new List<Quest>();
    QuestUI questUI;
    void Start()
    {
        questUI = FindObjectOfType<QuestUI>();
        // Initialized a quest to test system.
        quests.Add(new Quest("Flower Picker", "Pick 5 blue flowers to recieve a reward!", 5, 5));
    }

    public void CompleteQuest(string title)
    {
        // Search the list of quests, match the title and complete the quest.
        Quest quest = quests.Find(q => q.title == title);
        if (quest != null && !quest.isCompleted)
        {
            quest.CompleteQuest();
            // Temporarily display the quest is completed, for feedback.
            StartCoroutine(questUI.DisplayCompletion());
        }
    }

    public List<Quest> GetActiveQuests()
    {
        // Search through and return all quests that are not completed.
        return quests.FindAll(q => !q.isCompleted);
    }
}
