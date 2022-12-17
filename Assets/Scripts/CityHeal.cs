using UnityEngine;

public class CityHeal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("click it");
        var city = this.GetComponentInParent<City>();

        city.TreatInfection();
    }
}
