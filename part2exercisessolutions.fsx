// ---------------------------------------------------------------
//         EXERCISES
// ---------------------------------------------------------------
open System

// Design types for a domain of a simple calendar system. 
// It should handle e.g. one-time meetings, multiple-time meetings 
// and recurring meetings.
// The class for storing time is called DateTimeOffset.
type Meeting =
    | OneTime of DateTimeOffset
    | MultipleTimes of DateTimeOffset list
    | Recurring of DateTimeOffset * int


// Design a deck of card using DUs and Records
// Write function printing all cards in the deck
    /// Represents the suit of a playing card
    type Suit = 
        | Hearts 
        | Clubs 
        | Diamonds 
        | Spades

    /// Represents the rank of a playing card
    type Rank = 
        /// Represents the rank of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack
        static member GetAllRanks() = 
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]
                                   
    type Card =  { Suit: Suit; Rank: Rank }
              
    /// Returns a list representing all the cards in the deck
    let fullDeck = 
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do 
                  yield { Suit=suit; Rank=rank } ]


// Think about the domain you are working with recently. How would you model it using DUs and Records?