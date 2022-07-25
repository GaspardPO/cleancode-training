using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    /// <summary>
    ///     The Game
    /// </summary>
    public class Game
    {
        public enum Category
        {
            Sports,
            Rock,
            Pop,
            Science
        }

        private const int MAX_PLAYERS = 6;
        private const int _startingPoint = 0;
        private const int _numberOfCoinsAtStart = 0;
        private const int NUMBER_OF_COINS_TO_WIN = 6;
        private const int BOARD_SIZE = 12;
        private const int MAX_CATEGORIE_QUESTIONS = 50;

        private readonly bool[] _inPenaltyBox = new bool[MAX_PLAYERS];
        private readonly int[] _places = new int[MAX_PLAYERS];
        private readonly List<Player> _players = new List<Player>();

        private readonly LinkedList<string> _popDeck = new LinkedList<string>();
        private readonly LinkedList<string> _rockDeck = new LinkedList<string>();
        private readonly LinkedList<string> _scienceDeck = new LinkedList<string>();
        private readonly LinkedList<string> _sportsDeck = new LinkedList<string>();
        private readonly Logger _logger= new Logger();


        private int _currentPlayerIndex;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < MAX_CATEGORIE_QUESTIONS; i++)
            {
                _popDeck.AddLast(CreateQuestion(i, Category.Pop));
                _scienceDeck.AddLast(CreateQuestion(i, Category.Science));
                _sportsDeck.AddLast(CreateQuestion(i, Category.Sports));
                _rockDeck.AddLast(CreateQuestion(i, Category.Rock));
            }
        }

        private string CreateQuestion(int index, Category category)
        {
            return category + " Question " + index;
        }

        public bool Add(string playerName)
        {
            _players.Add(new Player(playerName));

            _places[HowManyPlayers()] = _startingPoint;
            _inPenaltyBox[HowManyPlayers()] = false;

            _logger.Log(playerName + " was added");
            _logger.Log("They are player number " + _players.Count);
            return true;
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            _logger.Log(_players[_currentPlayerIndex] + " is the current player");
            _logger.Log("They have rolled a " + roll);


            if (_inPenaltyBox[_currentPlayerIndex])
            {
                if (IsOdd(roll))
                {
                    //User is getting out of penalty box
                    _isGettingOutOfPenaltyBox = true;
                    //Write that user is getting out
                    _logger.Log(_players[_currentPlayerIndex] + " is getting out of the penalty box");
                    // add roll to place
                    MovePlayer(roll);

                    _logger.Log(_players[_currentPlayerIndex]
                                      + "'s new location is "
                                      + _places[_currentPlayerIndex]);
                    _logger.Log("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    _logger.Log(_players[_currentPlayerIndex] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                MovePlayer(roll);

                _logger.Log(_players[_currentPlayerIndex]
                                  + "'s new location is "
                                  + _places[_currentPlayerIndex]);
                _logger.Log("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void MovePlayer(int roll)
        {
            _places[_currentPlayerIndex] = _places[_currentPlayerIndex] + roll;
            if (_places[_currentPlayerIndex] >= BOARD_SIZE) _places[_currentPlayerIndex] = _places[_currentPlayerIndex] - BOARD_SIZE;
        }

        private static bool IsOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == Category.Pop)
            {
                _logger.Log(_popDeck.First());
                _popDeck.RemoveFirst();
            }

            if (CurrentCategory() == Category.Science)
            {
                _logger.Log(_scienceDeck.First());
                _scienceDeck.RemoveFirst();
            }

            if (CurrentCategory() == Category.Sports)
            {
                _logger.Log(_sportsDeck.First());
                _sportsDeck.RemoveFirst();
            }

            if (CurrentCategory() == Category.Rock)
            {
                _logger.Log(_rockDeck.First());
                _rockDeck.RemoveFirst();
            }
        }

        private Category CurrentCategory()
        {
            switch (_places[_currentPlayerIndex])
            {
                case 0:
                case 4:
                case 8:
                    return Category.Pop;
                case 1:
                case 5:
                case 9:
                    return Category.Science;
                case 2:
                case 6:
                case 10:
                    return Category.Sports;
                default:
                    return Category.Rock;
            }
        }

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WasCorrectlyAnswered()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            if (_inPenaltyBox[_currentPlayerIndex])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    _logger.Log("Answer was correct!!!!");
                    currentPlayer.EarnCoin();
                    _logger.Log(currentPlayer
                                      + " now has "
                                      + currentPlayer.Coins
                                      + " Gold Coins.");

                    var winner = currentPlayer.Coins != NUMBER_OF_COINS_TO_WIN;
                    ChangePlayer();

                    return winner;
                }

                ChangePlayer();
                return true;
            }

            {
                _logger.Log("Answer was corrent!!!!");
                currentPlayer.EarnCoin();
                _logger.Log(currentPlayer
                                  + " now has "
                                  + currentPlayer.Coins
                                  + " Gold Coins.");

                var winner = currentPlayer.Coins != NUMBER_OF_COINS_TO_WIN;
                ChangePlayer();

                return winner;
            }
        }

        private void ChangePlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count) _currentPlayerIndex = 0;
        }

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            _logger.Log("Question was incorrectly answered");
            _logger.Log(_players[_currentPlayerIndex] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayerIndex] = true;

            ChangePlayer();
            //Must alwys return false 
            return true;
        }

    }
}