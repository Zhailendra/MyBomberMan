using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    public enum PowerUpTypes
    {
        Bomb,
        Kick,
        Life,
        Power,
        Speed,
        Satellite
    }
}

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject bomb;
    public GameObject kick;
    public GameObject life;
    public GameObject power;
    public GameObject speed;
    public GameObject satellite;

    private GameObject toSpawn;
    
    public Objects.PowerUpTypes powerUp;

    private static int _speedPowerUpCount = 0;
    private static int _kickPowerUpCount = 0;
    private static int _remoteControlCount = 0;
    
    private const int MaxSpeedPowerUps = 2;
    private const int MaxKickPowerUps = 2;
    private const int MaxRemoteControlPowerUps = 2;

    void Start () 
    {
        powerUp = (Objects.PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(Objects.PowerUpTypes)).Length);

        while ((powerUp == Objects.PowerUpTypes.Speed && _speedPowerUpCount >= MaxSpeedPowerUps) ||
               (powerUp == Objects.PowerUpTypes.Kick && _kickPowerUpCount >= MaxKickPowerUps) ||
               (powerUp == Objects.PowerUpTypes.Satellite && _remoteControlCount >= MaxRemoteControlPowerUps))
        {
            powerUp = (Objects.PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(Objects.PowerUpTypes)).Length);
        }

        if (powerUp == Objects.PowerUpTypes.Speed)
        {
            _speedPowerUpCount++;
        }
        else if (powerUp == Objects.PowerUpTypes.Kick)
        {
            _kickPowerUpCount++;
        } 
        else if (powerUp == Objects.PowerUpTypes.Satellite)
        {
            _remoteControlCount++;
        }

        switch(powerUp)
        {
            case Objects.PowerUpTypes.Bomb:
                toSpawn = bomb;
                break;
            case Objects.PowerUpTypes.Kick:
                toSpawn = kick;
                break;
            case Objects.PowerUpTypes.Life:
                toSpawn = life;
                break;
            case Objects.PowerUpTypes.Power:
                toSpawn = power;
                break;
            case Objects.PowerUpTypes.Speed:
                toSpawn = speed;
                break;
            case Objects.PowerUpTypes.Satellite:
                toSpawn = satellite;
                break;
        }

        if (toSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);

            GameObject go = Instantiate(toSpawn, spawnPosition, Quaternion.identity);
            go.transform.SetParent(this.transform);
        }
        else
        {
            Debug.LogError("Missing power up prefab");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            
            switch (powerUp)
            {
                case Objects.PowerUpTypes.Bomb:
                    player.nbBombs++;
                    break;
                case Objects.PowerUpTypes.Kick:
                    player.unlockedPushableBombs = true;
                    break;
                case Objects.PowerUpTypes.Life:
                    player.lives++;
                    break;
                case Objects.PowerUpTypes.Power:
                    player.explosionRange++;
                    break;
                case Objects.PowerUpTypes.Speed:
                    player.moveSpeed++;
                    break;
                case Objects.PowerUpTypes.Satellite:
                    player.remoteControl = true;
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}