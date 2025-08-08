using System.Collections.Generic;
using Unity.Services.Authentication;//linking authentication dependency
using Unity.Services.CloudSave; //calling unity save package
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;
using System.Threading.Tasks;

public class CloudSave : MonoBehaviour
{
    public static CloudSave Instance { get; private set; } //singleton instance
    

    private void Awake() //initialising core services - authenticating for anonymous user profile - should be called automatically by unity
    {
        if (Instance == null && Instance != this) //checking if instance already exists - destroy new if old exists
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            SaveData(); //save user data
    }

    public async void SaveData() //Save anonymoyous player data - quoted text must be altered to suit game context
    {
        var playerData = new Dictionary<string, object>{
          {"firstKeyName", "a text value"},//firstkey is string
          {"secondKeyName", 123} //secondkey is int
        };
        await CloudSaveService.Instance.Data.Player.SaveAsync(playerData);
        Debug.Log($"Saved data {string.Join(',', playerData)}");
    }

    //public async Task LoadMetrics()
    //{
    //    const string coinKey = "LossCoinTitleCard";
    //    const string scoreKey = "LossScoreTitleCard";

    //    try
    //    {
    //        var loadedData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { coinKey, scoreKey });

    //        //check data existence - update UI
    //        if(loadedData.TryGetValue(scoreKey, out var scoreItem))
    //        {
    //            int score = scoreItem.Value.GetAs<int>();
    //            scoreItem.text = $"Score: {score}";
    //            Debug.Log($"Loaded score: {score}");
                    
    //        }
    //    }

    //}

    //public async void LoadData() //Load anonymoyous player data - quoted text must be altered to suit game context -- Omitted because load not needed at this stage in dev
    //{
    //    var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> {
    //      "firstKeyName", "secondKeyName"
    //    }); //loading playerData dictionary - so that key check can occur

    //    if (playerData.TryGetValue("firstKeyName", out var firstKey)) //check dictionary for player key/signature - retreive key if exists
    //    {
    //        Debug.Log($"firstKeyName value: {firstKey.Value.GetAs<string>()}");
    //    }

    //    if (playerData.TryGetValue("secondKeyName", out var secondKey)) //check dictionary for player key/signature - retreive key if exists
    //    {
    //        Debug.Log($"secondKey value: {secondKey.Value.GetAs<int>()}");
    //    }
    //}

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
