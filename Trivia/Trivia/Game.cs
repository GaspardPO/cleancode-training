namespace Trivia
{
    /// <summary>
    ///     The Game
    /// </summary>
    public class Game
    {
        
        private const int NUMBER_OF_COINS_TO_WIN = 6;
        

        private readonly PlayerGroup _players = new PlayerGroup();

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
            _logger.Log(_players.GetCurrent() + " is the current player");
            _logger.Log("They have rolled a " + roll);


            if (_players.GetCurrent().IsInPenaltyBox)
            {
                if (IsOdd(roll))
                {
                    //User is getting out of penalty box
                    _isGettingOutOfPenaltyBox = true;
                    //Write that user is getting out
                    _logger.Log(_players.GetCurrent() + " is getting out of the penalty box");
                    // add roll to place
                    _board.MoveForward(_players.GetCurrent(), roll);

                    _logger.Log(_players.GetCurrent()
                                      + "'s new location is "
                                      + _board.GetPosition(_players.GetCurrent()));
                    _logger.Log("The category is " + _board.CurrentCategory(_players.GetCurrent()));
                    AskQuestion();
                }
                else
                {
                    _logger.Log(_players.GetCurrent() + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                _board.MoveForward(_players.GetCurrent(), roll);

                _logger.Log(_players.GetCurrent()
                                  + "'s new location is "
                                  + _board.GetPosition(_players.GetCurrent()));
                _logger.Log("The category is " + _board.CurrentCategory(_players.GetCurrent()));
                AskQuestion();
            }
        }

        private static bool IsOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private void AskQuestion() 
        {
            _logger.Log(_mainDeck.Draw(_board.CurrentCategory(_players.GetCurrent())).ToString());
        }

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WasCorrectlyAnswered()
        {
            var currentPlayer = _players.GetCurrent();
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
                    _players.ChangePlayer();

                    return winner;
                }

                _players.ChangePlayer();
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
                _players.ChangePlayer();

                return winner;
            }
        }

        

        /// <summary>
        ///     To call when the answer is right
        /// </summary>
        /// <returns></returns>
        public bool WrongAnswer()
        {
            _logger.Log("Question was incorrectly answered");
            _logger.Log(_players.GetCurrent() + " was sent to the penalty box");
            _players.GetCurrent().GoToPenaltyBox();

            _players.ChangePlayer();
            //Must alwys return false 
            return true;
        }

    }
}