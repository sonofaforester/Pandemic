using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InfectionDeck : MonoBehaviour
{
    public IReadOnlyCollection<InfectionCard> Cards;

    // Start is called before the first frame update
    void Start()
    {
        var cities = GameObject.FindGameObjectsWithTag("City").Select(p => p.GetComponent<City>()).ToList();

        cities.Shuffle();

        var cardsList = new List<InfectionCard>();

        foreach (var city in cities)
        {
            cardsList.Add(new InfectionCard(city));
        }

        Cards = cardsList.AsReadOnly();
    }

    public InfectionCard DrawCard()
    {
        var deck = Cards.ToList();

        var nextCard = deck.First();

        Cards = deck.Skip(1).ToList().AsReadOnly();

        return nextCard;
    }

    // Update is called once per frame
    void Update()
    {

    }
}



