using UnityEngine;

namespace Objects
{
    public enum PowerUpTypes
    {
        Bomb,
        Kick,
        Life,
        Power,
        Speed
    }
}

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject bomb;
    public GameObject kick;
    public GameObject life;
    public GameObject power;
    public GameObject speed;

    private GameObject toSpawn;
    
    public Objects.PowerUpTypes powerUp;

    void Start () 
    {
        powerUp = (Objects.PowerUpTypes)Random.Range(0, System.Enum.GetValues(typeof(Objects.PowerUpTypes)).Length);

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
}