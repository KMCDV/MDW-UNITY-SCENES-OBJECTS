using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class CharacterStatisticsText : MonoBehaviour
{
   public TextMeshProUGUI TextMeshProUGUI;

   public Dictionary<string, CharacterStatistics> CharacterStatistics = new Dictionary<string, CharacterStatistics>();
   private void Awake()
   {
      Character.CharacterStatisticsUpdated += CharacterStatisticsOnCharacterStatisticsUpdated;
      Character.CharacterCreated += OnCharacterCreated;
      Character.CharacterDeleted += OnCharacterDelete;
   }

   private void OnCharacterDelete(object sender, CharacterUpdatedEventArgs e)
   {
      if (CharacterStatistics.ContainsKey(e.CharacterName))
         CharacterStatistics.Remove(e.CharacterName);
      UpdateText();
   }

   private void OnCharacterCreated(object sender, CharacterCreatedEventArgs e)
   {
      if(CharacterStatistics.ContainsKey(e.CharacterName))
         return;
      CharacterStatistics.Add(e.CharacterName, e.CharacterStatistics);
      UpdateText();
   }

   private void CharacterStatisticsOnCharacterStatisticsUpdated(object sender, CharacterUpdatedEventArgs e)
   {
      UpdateText();
   }

   private void UpdateText()
   {
      TextMeshProUGUI.text = "";
      foreach (KeyValuePair<string,CharacterStatistics> characterStatistic in CharacterStatistics)
      {
         TextMeshProUGUI.text += $"NAME: {characterStatistic.Key} Health: {characterStatistic.Value.Health} Armor: {characterStatistic.Value.Armor} \n";
      }
   }
}
