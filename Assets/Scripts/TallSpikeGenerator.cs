using UnityEngine;

public class TallSpikeGenerator : MonoBehaviour
{
    public GameObject TallSpike;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    void Awake()
    {
        currentSpeed = MinSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithGap()
    {
        float randomWait = Random.Range(0.2f, 2.4f);
        Invoke("generateSpike", randomWait);
    }

    public void generateSpike()
    {
        GameObject SpikeIns = Instantiate(TallSpike, transform.position, transform.rotation);

        SpikeIns.GetComponent<TallSpike>().spikeGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;

        }
    }
}