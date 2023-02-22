using System.Runtime.InteropServices.JavaScript;
using BaccaratTracker.Game;
using NUnit.Framework.Constraints;

namespace tests.Game;

public class HandTests
{
    private Hand emptyHand;
    private Hand nonEmptyHand;
    private Hand fullHand;

    [SetUp]
    public void SetUp()
    {
        emptyHand = new Hand();

        nonEmptyHand = new Hand();
        nonEmptyHand.AddCard(1);
        nonEmptyHand.AddCard(2);

        fullHand = new Hand();
        fullHand.AddCard(3);
        fullHand.AddCard(4);
        fullHand.AddCard(5);
    }

    [TearDown]
    public void TearDown()
    {
        emptyHand.ClearHand();
        nonEmptyHand.ClearHand();
        fullHand.ClearHand();
    }


    [Test]
    public void GIVEN_anEmptyHand_WHEN_gettingHandValue_THEN_shouldReturn0()
    {
        Assert.That(emptyHand.HandValue, Is.EqualTo(0));
    }

    [Test]
    public void GIVEN_anEmptyHand_WHEN_addingACard_THEN_cardIsAddedSuccessfully()
    {
        emptyHand.AddCard(6);
        
        Assert.That(emptyHand.Cards, Has.Length.EqualTo(1));
    }
    
    [Test]
    public void GIVEN_anEmptyHand_WHEN_addingACard_THEN_handValueIsUpdated()
    {
        emptyHand.AddCard(7);
        
        Assert.That(emptyHand.HandValue, Is.EqualTo(7));
    }

    [Test]
    public void GIVEN_aNonEmptyHand_WHEN_addingACard_THEN_CardIsAddedSuccessfully()
    {
        var initialAmountOfCards = nonEmptyHand.Cards.Length;
        nonEmptyHand.AddCard(8);
        
        Assert.That(nonEmptyHand.Cards, Has.Length.EqualTo(initialAmountOfCards + 1));
    }

    [Test]
    public void GIVEN_aNonEmptyHand_WHEN_addingACard_THEN_handValueIsUpdated()
    {
        var initialHandValue = nonEmptyHand.HandValue;
        nonEmptyHand.AddCard(9);
        
        Assert.That(nonEmptyHand.HandValue, Is.Not.EqualTo(initialHandValue));
    }

    [Test]
    public void GIVEN_aFullHand_WHEN_addingACard_THEN_noCardIsAdded()
    {
        var initialAmountOfCards = fullHand.Cards.Length;
        fullHand.AddCard(10);
        
        Assert.That(fullHand.Cards, Has.Length.EqualTo(initialAmountOfCards));
    }

    [Test]
    public void GIVEN_aFullHand_WHEN_addingACard_THEN_handValueIsUnchanged()
    {
        var initialHandValue = nonEmptyHand.HandValue;
        nonEmptyHand.AddCard(11);
        
        Assert.That(nonEmptyHand.HandValue, Is.EqualTo(initialHandValue));
    }

    [Test]
    public void GIVEN_aCardSumOf10_WHEN_gettingHandValue_THEN_shouldReturn0()
    {
        emptyHand.AddCard(5);
        emptyHand.AddCard(5);
        
        Assert.That(emptyHand.HandValue, Is.EqualTo(0));
    }
    
    [Test]
    public void GIVEN_aCardSumOfMoreThan10_WHEN_gettingHandValue_THEN_shouldReturnSumMinus10()
    {
        emptyHand.AddCard(6);
        emptyHand.AddCard(6);
        
        Assert.That(emptyHand.HandValue, Is.EqualTo(2));
    }
    
    [Test]
    public void GIVEN_aHandWithOnlyFaceCards_WHEN_gettingHandValue_THEN_shouldReturn0()
    {
        emptyHand.AddCard(13);
        emptyHand.AddCard(12);
        emptyHand.AddCard(11);
        
        Assert.That(emptyHand.HandValue, Is.EqualTo(0));
    }
    
    [Test]
    public void GIVEN_aNonFullHand_WHEN_addingAFaceCard_THEN_handValueShouldRemainTheSame()
    {
        var initialHandValue = nonEmptyHand.HandValue;
        nonEmptyHand.AddCard(11);

        Assert.That(nonEmptyHand.HandValue, Is.EqualTo(initialHandValue));
    }
    
    [Test]
    public void GIVEN_aNonEmptyHand_WHEN_clearingHand_THEN_handShouldBecomeEmpty()
    {
        nonEmptyHand.ClearHand();
        
        Assert.That(nonEmptyHand.Cards, Has.Length.EqualTo(0));
    }
    
    [Test]
    public void GIVEN_aNonEmptyHand_WHEN_clearingHand_THEN_handValueShouldBe0()
    {
        nonEmptyHand.ClearHand();
        
        Assert.That(nonEmptyHand.HandValue, Is.EqualTo(0));
    }
    
    [Test]
    public void GIVEN_anEmptyHand_WHEN_callingIsHandFull_THEN_returnsFalse()
    {
        Assert.That(emptyHand.IsHandFull(), Is.False);
    }
    
    [Test]
    public void GIVEN_aNonEmptyHand_WHEN_callingIsHandFull_THEN_returnsFalse()
    {
        Assert.That(nonEmptyHand.IsHandFull(), Is.False);
    }
        
    [Test]
    public void GIVEN_aFullHand_WHEN_callingIsHandFull_THEN_returnsTrue()
    {
        Assert.That(fullHand.IsHandFull(), Is.True);
    }

}
