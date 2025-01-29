using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Expose fields in inspector.
[System.Serializable]
public class Quest
{
    // Quest data.
    public string title;
    public string description;
    public int collected = 0;
    public int condition;
    public int reward;
    public bool isCompleted;

    // Constructor for quest. Pass values when initializing a new quest.
    public Quest(string title, string description, int condition, int reward)
    {
        this.title = title;
        this.description = description;
        this.condition = condition;
        this.reward = reward;
        this.isCompleted = false;
    }

    public void CompleteQuest()
    {
        // Check if the quest is completed.
        if (collected == condition)
        {
            isCompleted = true;
            Debug.Log("Quest completed: " + title);
        }
    }
}
