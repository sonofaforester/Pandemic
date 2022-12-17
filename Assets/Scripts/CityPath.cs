using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CityPath : MonoBehaviour
{
    private City _city;
    private GamePlay _board;

    // Start is called before the first frame update
    void Start()
    {
        _city = this.transform.parent.GetComponent<City>();
        _board = GamePlay.GamePlayInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private List<City> GetShortestPath(City from, City to, int maxHops) {
        var pathAttempts = new Queue<Tuple<PotentialCityPath,int>>();

        pathAttempts.Enqueue(new Tuple<PotentialCityPath,int>(new PotentialCityPath(new List<City>() { from }), 0));

        while(true) {
            var startCity = pathAttempts.Dequeue();

            var attemptNumber = startCity.Item2 + 1;

            if(attemptNumber > maxHops) {
                return new List<City>();
            }


            foreach(var city in startCity.Item1.Cities.Last().ConnectedCities) {
                var path = startCity.Item1.Cities.ToList();
                path.Add(city);

                if(city.name == to.name) {
                    return path.Skip(1).ToList();
                }                

                pathAttempts.Enqueue(new Tuple<PotentialCityPath, int>(new PotentialCityPath(path), attemptNumber)); 
            }
        }
    }

    public void OnMouseOver() {
        var path = GetShortestPath(_board.CurrentPlayer.CurrentCity, _city, _board.CurrentPlayer.PendingMoves);

        if(path.Any()) {
            _city.ShimmerOn();
        }
        
    }

    public void OnMouseExit() {
        _city.ShimmerOff();
    }

    public void OnMouseDown() {
        
        var path = GetShortestPath(_board.CurrentPlayer.CurrentCity, _city, _board.CurrentPlayer.PendingMoves);

        if(path.Any()) {
            _board.MoveCurrentPlayerAlongPath(path);
        }
    }
}

class PotentialCityPath {
    public PotentialCityPath(List<City> cities)
    {
        Cities = cities.AsReadOnly();
    }

    public ReadOnlyCollection<City> Cities { get; }
}
