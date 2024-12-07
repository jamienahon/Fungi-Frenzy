using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] smallObs;
    public GameObject[] bigObs;

    public float cooldown;
    float nextSpawn;

    public float timeBetweenSteps;
    float nextStep;

    public float timeBetweenSpeedUps;
    float nextSpeedUp;

    public int maxObstacles = 1;
    public int minObstacles = 1;

    public float speed;

    void Start()
    {
        nextSpawn = Time.time + cooldown;
        nextStep = Time.time + timeBetweenSteps;
        nextSpeedUp = Time.time + timeBetweenSpeedUps;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnObstacles();

            nextSpawn = Time.time + cooldown;
        }

        if (Time.time > nextStep)
        {
            if (maxObstacles < 3)
                maxObstacles += 1;
            else
                minObstacles += 1;
                
            nextStep = Time.time + timeBetweenSteps;
        }

        if (Time.time > nextSpeedUp)
        {
            speed += 0.1f;
            nextSpeedUp = Time.time + timeBetweenSpeedUps;
            cooldown -= 0.005f;
        }
    }

    private void SpawnObstacles()
    {
        int numberOfObstacled = Random.Range(1, maxObstacles + 1);

        GameObject[] row = new GameObject[3] { null, null, null };

        if (numberOfObstacled == 1)
        {
            int type = Random.Range(0, 2);
            int itemPosition = Random.Range(0, 3);

            int item = Random.Range(0, 3);
            if(type == 0)
                row[itemPosition] = smallObs[item];
            if(type == 1)
                row[itemPosition] = bigObs[item];
        }
        else if (numberOfObstacled == 2)
        {
            int type1 = Random.Range(0, 2);
            int type2 = Random.Range(0, 2);

            int item1Position = Random.Range(0, 3);
            int item1 = Random.Range(0, 3);
            if (type1 == 0)
                row[item1Position] = smallObs[item1];
            if (type1 == 1)
                row[item1Position] = bigObs[item1];

            int item2Position = Random.Range(0, 3);
            while (row[item2Position] != null)
            {
                item2Position = Random.Range(0, 3);
            }
            int item2 = Random.Range(0, 3);
            if (type2 == 0)
                row[item2Position] = smallObs[item2];
            if (type2 == 1)
                row[item2Position] = bigObs[item2];
        }
        else
        {
            int type1 = Random.Range(0, 2);
            int type2 = Random.Range(0, 2);
            int type3;
            if (type1 + type2 == 2)
                type3 = 0;
            else
                type3 = Random.Range(0, 2);

            int item1Position = Random.Range(0, 3);
            int item1 = Random.Range(0, 3);
            if (type1 == 0)
                row[item1Position] = smallObs[item1];
            if (type1 == 1)
                row[item1Position] = bigObs[item1];

            int item2Position = Random.Range(0, 3);
            while (row[item2Position] != null)
            {
                item2Position = Random.Range(0, 3);
            }
            int item2 = Random.Range(0, 3);
            if (type2 == 0)
                row[item2Position] = smallObs[item2];
            if (type2 == 1)
                row[item2Position] = bigObs[item2];

            int item3Position = Random.Range(0, 3);
            while (row[item3Position] != null)
            {
                item3Position = Random.Range(0, 3);
            }
            int item3 = Random.Range(0, 3);
            if (type3 == 0)
                row[item3Position] = smallObs[item3];
            if (type3 == 1)
                row[item3Position] = bigObs[item3];
        }

        for (int i = 0; i < row.Length; i++)
        {
            if (row[i] != null)
            {
                GameObject obj = Instantiate(row[i]);
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + Random.Range(-3, 4));
                Sprite sprite = obj.GetComponent<Sprite>();
                sprite.speed = speed;
                if (i == 0)
                {
                    sprite.lookAtTarget = GameObject.Find("LookAtLeft");
                    sprite.transform.position = new Vector3(-2.5f, sprite.transform.position.y, sprite.transform.position.z);
                }
                else if (i == 1)
                {
                    sprite.lookAtTarget = GameObject.Find("LookAtMiddle");
                    sprite.transform.position = new Vector3(0, sprite.transform.position.y, sprite.transform.position.z);
                }
                else
                {
                    sprite.lookAtTarget = GameObject.Find("LookAtRight");
                    sprite.transform.position = new Vector3(2.5f, sprite.transform.position.y, sprite.transform.position.z);
                }

            }
        }
    }
}
