using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Diseases : MonoBehaviour
{
    private Dictionary<Region, DiseasePile> _diseasePiles;

    // Start is called before the first frame update
    void Start()
    {
        _diseasePiles = new Dictionary<Region, DiseasePile>();

        var diseasePiles = gameObject.GetComponentsInChildren<DiseasePile>();

        foreach (var diseasePile in diseasePiles)
        {
            _diseasePiles.Add(diseasePile.Region, diseasePile);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Disease DeployDisease(City toCity)
    {
        return _diseasePiles[toCity.Region].DeployDisease(toCity);
    }
}
