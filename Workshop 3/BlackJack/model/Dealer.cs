﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.WinRules m_winRules;

        private CardDisplayer cardDisplayer;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRules = a_rulesFactory.GetEasyWinningRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }
            return false;
        }

        public bool Stand()
        {
            Card c;
            
            if (m_deck != null)
            {
                ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    
                   c = m_deck.GetCard();
                   c.Show(true);
                   DealCard(c);
                   return true;
                }
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (m_winRules.EasyWinningRule(this, a_player) == false)
            {
                return false;
            }
            return true;
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void Deal(Player a_player, bool visible)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(visible);
            a_player.DealCard(c);

            cardDisplayer.CardDisplayer();
        }

        public void RegisterCardDisplayer(CardDisplayer cardDisplayer)
        {
            this.cardDisplayer = cardDisplayer;
        }
    }
}
