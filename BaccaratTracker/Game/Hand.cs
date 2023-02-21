using System.Collections.Generic;

namespace BaccaratTracker.Game;

public class Hand
{
    private List<int> cards = new List<int>();

    public int[] Cards => cards.ToArray();

    public int HandValue { get; }

    public void AddCard(int newCard)
    {
        // ignore implementation until tests are done
        // if (cards.Count < 3)
        // {
        //     cards.Add(newCard);
        //     UpdateHandValue();
        // }
    }

    public void ClearHand() {}

    protected static void UpdateHandValue() { }
}
