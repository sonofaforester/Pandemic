using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public IReadOnlyCollection<PlayerCard> Cards { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<PlayerCard>().AsReadOnly();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CanTakeCard()
    {
        if (Cards.Count < 6)
            return true;

        return false;
    }

    public void PlaceCardInHand(PlayerCard card)
    {
        if (!CanTakeCard())
            throw new System.Exception("Can't add more cards to hand");

        var newSet = Cards.ToList();
        newSet.Add(card);
        Cards = newSet.AsReadOnly();

        var cardObjects = GameObject.FindGameObjectsWithTag("PlayerHandCard").Select(c => c.GetComponent<PlayerCardScript>());

        for (int i = 0; i < 6; i++)
        {
            Debug.Log(cardObjects.ElementAt(i).name);

            if (Cards.Count >= i + 1)
                cardObjects.ElementAt(i).Card = Cards.ElementAt(i);
            else
                cardObjects.ElementAt(i).Card = null;
        }
    }
}
