using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : BlackJack.model.CardDisplayer
    {
        private view.IView view;
        private model.Game game;
        
        
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_game.RegisterNewCardDealer(this);

            this.game = a_game;
            this.view = a_view;
            CardDisplayer();

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            int input = a_view.GetInput();

            switch (input)
            {
                case 1: { a_game.NewGame(); break; }
                case 2: { a_game.Hit(); break; }
                case 3: { a_game.Stand(); break; }
                case 4: { return input != 4; }
            }
            return input != 4;
        }

        public void CardDisplayer()
        {
            this.view.DisplayWelcomeMessage();

            this.view.DisplayDealerHand(this.game.GetDealerHand(), this.game.GetDealerScore());
            this.view.DisplayPlayerHand(this.game.GetPlayerHand(), this.game.GetPlayerScore());
            Thread.Sleep(1500);
        }
    }
}
