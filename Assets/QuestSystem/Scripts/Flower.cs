using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Note to self: Should be reusable for any quest item in future.
    // References to quest manager and UI.
    QuestManager questManager;
    QuestUI questUI;
    
    void Start()
    {
        // Cache the references.
        questManager = FindObjectOfType<QuestManager>();
        questUI = FindObjectOfType<QuestUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pick up flower, update quest list and destroy the flower.
        questManager.quests[0].collected += 1;
        questUI.UpdateQuestList();
        Destroy(gameObject);
    }


}
