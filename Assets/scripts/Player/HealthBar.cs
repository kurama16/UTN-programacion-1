using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private List<HealthHeart> hearts = new List<HealthHeart>();

    private void Start()
    {
        DrawHearts();
    }

    private void OnEnable(){
        PlayerHealth.OnPlayerDamaged +=DrawHearts;
    }

    private void OnDisable(){
        PlayerHealth.OnPlayerDamaged -=DrawHearts;
    }
    
    public void CreateHeart(HealthHeart.HeartStatus status)
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(status);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }

    public void DrawHearts()
    {
        ClearHearts();
        int maxHealth = playerHealth.MaxHearts;
        int fullHeartsToMake = playerHealth.CurrentHearts;
        int halfHeartsToMake = playerHealth.HasHalfHeart ? 1 : 0;
        int emptyHeartsToMake = maxHealth - fullHeartsToMake - halfHeartsToMake;
        for (int i = 0; i < fullHeartsToMake; i++)
        {
            CreateHeart(HealthHeart.HeartStatus.Full);
        }
        for (int i = 0; i < halfHeartsToMake; i++)
        {
            CreateHeart(HealthHeart.HeartStatus.Half);
        }

        for (int i = 0; i < emptyHeartsToMake; i++)
        {
            CreateHeart(HealthHeart.HeartStatus.Empty);
        }

    }

}
