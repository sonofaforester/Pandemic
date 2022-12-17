using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public int NumberOfPlayers;
    private List<Player> _players = new List<Player>();
    private int _currentPlayerNumber = 0;

    void Start()
    {
        GameSetup();
    }


    public void MoveCurrentPlayerAlongPath(List<City> path)
    {
        foreach (var city in path)
        {
            CurrentPlayer.GoToCity(city);

            if (CurrentPlayer.PendingMoves == 0)
            {
                ChangePlayer();
            }
        }
    }

    public void ChangePlayer()
    {
        CurrentPlayer.EndTurn();

        _currentPlayerNumber++;

        if (_currentPlayerNumber >= NumberOfPlayers)
            _currentPlayerNumber = 0;

        CurrentPlayer.StartTurn();
    }

    public Player CurrentPlayer
    {
        get
        {
            return _players.ElementAt(_currentPlayerNumber);
        }
    }

    public void GameSetup()
    {
        var atlanta = GameObject.Find("Atlanta").GetComponent<City>();

        var players = GameObject.FindGameObjectsWithTag("Player").ToList();

        var playerOrder = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        playerOrder.Shuffle();

        for (int i = 0; i < 7; i++)
        {
            var player = players.ElementAt(playerOrder.ElementAt(i));

            if (i < NumberOfPlayers)
            {
                var playerComp = player.GetComponent<Player>();
                playerComp.CurrentCity = atlanta;
                _players.Add(playerComp);
            }
            else
            {
                player.SetActive(false);
            }
        }

        var infectionDeck = GameObject.Find("InfectionDeck").GetComponent<InfectionDeck>();
        var diseases = GameObject.Find("Diseases").GetComponent<Diseases>();

        for (int i = 0; i < 3; i++) //3 cities each
        {
            for (int j = 0; j < 3; j++) //Number of diseases per city
            {
                var card = infectionDeck.DrawCard();

                for (int k = 0; k <= j; k++)
                {
                    diseases.DeployDisease(card.City);
                }
            }
        }

        CurrentPlayer.StartTurn();
    }

    public static GamePlay GamePlayInstance
    {
        get
        {
            return GameObject.Find("Board").GetComponent<GamePlay>();
        }
    }

    public void DealTwoCardsToCurrentPlayer()
    {
        var playerDeck = GameObject.Find("PlayerDeck").GetComponent<PlayerDeck>();
        var playerHand = GameObject.Find("PlayerHand").GetComponent<PlayerHand>();

        var card = playerDeck.DrawCard();
        playerHand.PlaceCardInHand(card);

        card = playerDeck.DrawCard();
        playerHand.PlaceCardInHand(card);
    }

}
