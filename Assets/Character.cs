using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Character : MonoBehaviour
    {
        public static event EventHandler<CharacterUpdatedEventArgs> CharacterStatisticsUpdated;
        public static event EventHandler<CharacterCreatedEventArgs> CharacterCreated;
        public static event EventHandler<CharacterUpdatedEventArgs> CharacterDeleted;
        
        public CharacterStatistics characterStatistics;
        private float updateDelay = 3f;
        public string characterName;

        private void Awake()
        {
            characterName = Guid.NewGuid().ToString();
            NiestacjoSceneLoader.GameFullyLoaded += OnGameFullyLoaded;
        }

        private void OnGameFullyLoaded(object sender, EventArgs e)
        {
            characterStatistics = Instantiate(characterStatistics);
            CharacterCreated?.Invoke(this, 
                new CharacterCreatedEventArgs{CharacterName = characterName,
                    CharacterStatistics = characterStatistics});        
        }


        private void Update()
        {
            updateDelay -= Time.deltaTime;
            if (updateDelay <= 0)
            {
                characterStatistics.Health -= 1;
                CharacterUpdatedEventArgs updatedEventArgs = new CharacterUpdatedEventArgs();
                updatedEventArgs.CharacterName = characterName;
                CharacterStatisticsUpdated?.Invoke(this, updatedEventArgs);
                updateDelay = Random.Range(0.5f, 2f);
            }
        }

        private void OnDestroy()
        {
            CharacterDeleted?.Invoke(this, new CharacterUpdatedEventArgs{CharacterName = characterName});
        }
    }

    public class CharacterUpdatedEventArgs : EventArgs
    {
        public string CharacterName;
    }

    public class CharacterCreatedEventArgs : EventArgs
    {
        public string CharacterName;
        public CharacterStatistics CharacterStatistics;
    }

}