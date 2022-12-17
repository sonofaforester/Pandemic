using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiseasePile : MonoBehaviour
{
    private Queue<Disease> _parkedDiseases;
    private List<Disease> _deployedDiseases;

    public Region Region;

    // Start is called before the first frame update
    void Start()
    {
        _parkedDiseases = new Queue<Disease>();
        _deployedDiseases = new List<Disease>();

        var diseases = gameObject.GetComponentsInChildren<Disease>();

        for (int i = 0; i < diseases.Count(); i++)
        {
            _parkedDiseases.Enqueue(diseases.ElementAt(i));
            diseases.ElementAt(i).SetPilePosition(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Disease DeployDisease(City toCity)
    {
        var disease = _parkedDiseases.Dequeue();
        disease.SetCity(toCity);
        _deployedDiseases.Add(disease);
        toCity.AddInfection(disease);
        return disease;
    }

}
