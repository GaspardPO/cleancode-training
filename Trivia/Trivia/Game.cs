using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    /// <summary>
    /// The Game
    /// </summary>
    public class Game
    {
        private const int MAX_PLAYERS = 6;

        private readonly List<string> _players = new List<string>();

        private readonly int[] _places = new int[MAX_PLAYERS];
        private readonly int[] _purses = new int[MAX_PLAYERS];
        private readonly bool[] _inPenaltyBox = new bool[MAX_PLAYERS];

        private readonly LinkedList<string> _popDeck = new LinkedList<string>();
        private readonly LinkedList<string> _scienceDeck = new LinkedList<string>();
        private readonly LinkedList<string> _sportsDeck = new LinkedList<string>();
        private readonly LinkedList<string> _rockDeck = new LinkedList<string>();


        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;
        const int _startingPoint = 0;
        const int _numberOfCoinsAtStart = 0;
        private const int NUMBER_OF_COINS_TO_WIN = 6;
        private const int BOARD_SIZE = 12;
        private const int MAX_CATEGORIE_QUESTIONS = 50;

        public Game()
        {
            for (var i = 0; i < MAX_CATEGORIE_QUESTIONS; i++)
            {
                _popDeck.AddLast("Pop Question " + i);
                _scienceDeck.AddLast(("Science Question " + i));
                _sportsDeck.AddLast(("Sports Question " + i));
                _rockDeck.AddLast(CreateRockQuestion(i));
            }
        }

        private string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }
        
        public bool Add(string playerName)
        {
            _players.Add(playerName);

            _places[HowManyPlayers()] = _startingPoint;
            _purses[HowManyPlayers()] = _numberOfCoinsAtStart;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player"); Console.WriteLine("They have rolled a " + roll);


            if (_inPenaltyBox[_currentPlayer])
            {
                if (IsOdd(roll))
                {
                    //User is getting out of penalty box
                    _isGettingOutOfPenaltyBox = true;
                    //Write that user is getting out
                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    // add roll to place
                    MovePlayer(roll);

                    Console.WriteLine(_players[_currentPlayer]
                            + "'s new location is "
                            + _places[_currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                MovePlayer(roll);

                Console.WriteLine(_players[_currentPlayer]
                        + "'s new location is "
                        + _places[_currentPlayer]);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void MovePlayer(int roll)
        {
            _places[_currentPlayer] = _places[_currentPlayer] + roll;
            if (_places[_currentPlayer] >= BOARD_SIZE) _places[_currentPlayer] = _places[_currentPlayer] - BOARD_SIZE;
        }

        private static bool IsOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popDeck.First());
                _popDeck.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceDeck.First());
                _scienceDeck.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportsDeck.First());
                _sportsDeck.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_rockDeck.First());
                _rockDeck.RemoveFirst();
            }
        }

        private string CurrentCategory()
        {
            if (_places[_currentPlayer] == 0) return "Pop";
            if (_places[_currentPlayer] == 4) return "Pop";
            if (_places[_currentPlayer] == 8) return "Pop";
            if (_places[_currentPlayer] == 1) return "Science";
            if (_places[_currentPlayer] == 5) return "Science";
            if (_places[_currentPlayer] == 9) return "Science";
            if (_places[_currentPlayer] == 2) return "Sports";
            if (_places[_currentPlayer] == 6) return "Sports";
            if (_places[_currentPlayer] == 10) return "Sports";
            return "Rock";
        }


        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WasCorrectlyAnswered()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _purses[_currentPlayer]++;
                    Console.WriteLine(_players[_currentPlayer]
                            + " now has "
                            + _purses[_currentPlayer]
                            + " Gold Coins.");

                    var winner = _purses[_currentPlayer] != NUMBER_OF_COINS_TO_WIN;
                    ChangePlayer();

                    return winner;
                }
                else
                {
                    ChangePlayer();
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                _purses[_currentPlayer]++;
                Console.WriteLine(_players[_currentPlayer]
                        + " now has "
                        + _purses[_currentPlayer]
                        + " Gold Coins.");

                var winner = _purses[_currentPlayer] != NUMBER_OF_COINS_TO_WIN;
                ChangePlayer();

                return winner;
            }
        }

        private void ChangePlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        /// <summary>
        /// To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            ChangePlayer();
            //Must alwys return false 
            return true;
        }


    }

}
