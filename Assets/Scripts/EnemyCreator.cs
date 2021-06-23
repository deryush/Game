using UnityEngine;
using UnityEngine.UI;

public class EnemyCreator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float CreationPeriod;
    private float timer;

    public float randomOffsetValue;
    [Space]
    public int NumberOfEnemy = 0;
    public int MaxEnemy;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= CreationPeriod)
        {
           
            Vector3 randomOffset = new Vector3(Random.Range(-randomOffsetValue, randomOffsetValue), 0,
                Random.Range(-randomOffsetValue, randomOffsetValue));

            if (NumberOfEnemy < MaxEnemy)
            {
                Instantiate(EnemyPrefab, transform.position + randomOffset, transform.rotation);
                timer = 0;
                NumberOfEnemy++;
            }
        }
    }
}
