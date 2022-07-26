using System.Collections.Generic;

namespace Trivia
{
    /// <summary>
    ///     The Game
    /// </summary>
    public class Game
    {
        
        private const int _startingPoint = 0;
        private const int NUMBER_OF_COINS_TO_WIN = 6;
        private const int BOARD_SIZE = 12;

        private int _currentPlayerIndex;
        private const int MAX_PLAYERS = 6;
        private readonly int[] _places = new int[MAX_PLAYERS];
        private readonly List<Player> _players = new List<Player>();

        private const int MAX_CATEGORIE_QUESTIONS = 50;
        private readonly Deck _popDeck = new Deck(Question.Categories.Pop, MAX_CATEGORIE_QUESTIONS);
        private readonly Deck _rockDeck = new Deck(Question.Categories.Rock, MAX_CATEGORIE_QUESTIONS);
        private readonly Deck _scienceDeck = new Deck(Question.Categories.Science, MAX_CATEGORIE_QUESTIONS);
        private readonly Deck _sportDeck = new Deck(Question.Categories.Sports, MAX_CATEGORIE_QUESTIONS);
        
        private readonly Logger _logger = new Logger();
        
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {

        }

        public bool Add(string playerName)
        {
            _players.Add(new Player(playerName));

            _places[HowManyPlayers()] = _startingPoint;

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


            if (_players[_currentPlayerIndex].IsInPenaltyBox)
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
            if (CurrentCategory() == Question.Categories.Pop)
            {
                _logger.Log(_popDeck.Draw().ToString());
            }

            if (CurrentCategory() == Question.Categories.Science)
            {
                _logger.Log(_scienceDeck.Draw().ToString());
            }

            if (CurrentCategory() == Question.Categories.Sports)
            {
                _logger.Log(_sportDeck.Draw().ToString());
            }

            if (CurrentCategory() == Question.Categories.Rock)
            {
                _logger.Log(_rockDeck.Draw().ToString());
            }
        }

        private Question.Categories CurrentCategory()
        {
            switch (_places[_currentPlayerIndex])
            {
                case 0:
                case 4:
                case 8:
                    return Question.Categories.Pop;
                case 1:
                case 5:
                case 9:
                    return Question.Categories.Science;
                case 2:
                case 6:
                case 10:
                    return Question.Categories.Sports;
                default:
                    return Question.Categories.Rock;
            }
        }

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WasCorrectlyAnswered()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            if (currentPlayer.IsInPenaltyBox)
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
            _players[_currentPlayerIndex].GoToPenaltyBox();

            ChangePlayer();
            //Must alwys return false 
            return true;
        }

    }
}