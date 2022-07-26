using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    /// <summary>
    ///     The Game
    /// </summary>
    public class Game
    {
        
        private const int NUMBER_OF_COINS_TO_WIN = 6;
        

        private int _currentPlayerIndex;
        private readonly List<Player> _players = new List<Player>();

        private readonly Logger _logger = new Logger();
        
        private bool _isGettingOutOfPenaltyBox;
        private const int NB_QUESTIONS_BY_CATEGORY = 50;
        private MainDeck _mainDeck = new MainDeck(NB_QUESTIONS_BY_CATEGORY);
        private Board _board = new Board();

        public Game()
        {

        }

        public bool Add(string playerName)
        {
            var player = new Player(playerName);
            _players.Add(player);

            _board.PlaceAtStart(player);

            _logger.Log(playerName + " was added");
            _logger.Log("They are player number " + _players.Count);
            return true;
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
                    _board.MoveForward(_players[_currentPlayerIndex], roll);

                    _logger.Log(_players[_currentPlayerIndex]
                                      + "'s new location is "
                                      + _board.GetPosition(_players[_currentPlayerIndex]));
                    _logger.Log("The category is " + _board.CurrentCategory(_players[_currentPlayerIndex]));
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
                _board.MoveForward(_players[_currentPlayerIndex], roll);

                _logger.Log(_players[_currentPlayerIndex]
                                  + "'s new location is "
                                  + _board.GetPosition(_players[_currentPlayerIndex]));
                _logger.Log("The category is " + _board.CurrentCategory(_players[_currentPlayerIndex]));
                AskQuestion();
            }
        }

        private static bool IsOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private void AskQuestion() 
        {
            _logger.Log(_mainDeck.Draw(_board.CurrentCategory(_players[_currentPlayerIndex])).ToString());
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