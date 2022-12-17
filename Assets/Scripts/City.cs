using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    private bool _shimmering = false;

    // Start is called before the first frame update
    void Start()
    {
        Validate();
        SetColor();

        var cityName = GetComponentInChildren<Text>();
        cityName.text = name;
    }

    public City[] ConnectedCities;
    public Region Region;
    private List<Disease> _diseases = new List<Disease>();

    // Update is called once per frame
    void Update()
    {

    }

    void Validate()
    {
        foreach (var city in ConnectedCities)
        {
            if (!city.ConnectedCities.Any(c => c.name == name))
                Debug.Log(city.name + " doesn't connect to " + name);
        }
    }

    public void ShimmerOn()
    {
        var cubeRenderer = GetComponentInChildren<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.gray);
    }

    public void ShimmerOff()
    {
        SetColor();
    }

    public void AddInfection(Disease disease)
    {
        _diseases.Add(disease);

        var diseases = this.GetComponentsInChildren<CityDisease>();

        switch (_diseases.Count())
        {
            case 1:
                diseases.First(d => d.name == "CityDisease1").SetDisease(disease);
                break;
            case 2:
                diseases.First(d => d.name == "CityDisease2").SetDisease(disease);
                break;
            case 3:
                diseases.First(d => d.name == "CityDisease3").SetDisease(disease);
                break;
            default:
                throw new Exception("Too many diseases");
        }
    }

    public void TreatInfection()
    {
        var diseases = this.GetComponentsInChildren<CityDisease>();

        switch (_diseases.Count())
        {
            case 1:
                diseases.First(d => d.name == "CityDisease1").HealDisease();
                break;
            case 2:
                diseases.First(d => d.name == "CityDisease2").HealDisease();
                break;
            case 3:
                diseases.First(d => d.name == "CityDisease3").HealDisease();
                break;
        }

        var healedDisease = _diseases.Last();

        healedDisease.SetCity(null);

        _diseases.Remove(healedDisease);
    }

    void SetColor()
    {
        var cubeRenderer = this.GetComponentInChildren<Renderer>();
        cubeRenderer.material.SetColor("_Color", Region.GetColor());
    }

    public static City FindCityByName(string name)
    {
        foreach (var city in GameObject.FindGameObjectsWithTag("City"))
        {
            if (city.name == name)
                return city.GetComponent<City>();
        }

        return null;
    }


}
