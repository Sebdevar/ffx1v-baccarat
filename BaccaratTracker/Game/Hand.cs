using System.Collections.Generic;

namespace BaccaratTracker.Game;

public class Hand
{
    private readonly List<int> cards = new();

    public int[] Cards => cards.ToArray();

    public int HandValue { get; private set; }

    public void AddCard(int newCard)
    {
        if (cards.Count < 3)
        {
            cards.Add(newCard);
            AddToHandValue(newCard);
        }
    }

    public void ClearHand()
    {
        cards.Clear();
        HandValue = 0;
    }

    protected void AddToHandValue(int newValue)
    {
        if (newValue < 10)
        {
            HandValue += newValue;
            if (HandValue > 9)
            {
                HandValue -= 10;
            }
        }
    }
}
