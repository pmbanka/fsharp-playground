open System

/// PART II

module RecordTypes = 
    // https://sharplab.io/#f:fs/AQ4FwTwBwU2BhA9gOzAQwMZnmgTgE2AF5gBYAKFCuAG9gA5NAWzgC5gBnMXAS2QHMA3BWrUACgAsUbTtz5CRo0ADUYvAGY8YhdgCNEiADbAAvkA=
    // define a record type
    type ContactCard = 
        { Name : string;
          Phone : string;
          Verified : bool }
              
    let contact1 = { Name = "Alf" ; Phone = "(206) 555-0157" ; Verified = false }

    // create a new record that is a copy of contact1, 
    // but has different values for the 'Phone' and 'Verified' fields
    let contact2 = { contact1 with Phone = "(206) 555-0112"; Verified = true }       


module UnionTypes = 
    // define a union type
    // https://sharplab.io/#f:fs/AQ4FwTwBwU2BlAFgQ1sAvAWAFCj8AH2AGEBLAJwGMAbOAewDNgHq7kwd9QiAlGSsMgB2AcwCu1ZOWCNmrdsABUcth1xdCCAI5ip9Ji1VA===
    type Shape =
        | Circle of float
        | Rectangular of float * float
        | Square of float

    let area s =
        match s with
        | Circle r -> System.Math.PI * r * r
        | Rectangular (x, y) -> x * y
        | Square x -> x*x
    
    let s = Square 10.0

    let r = Rectangular (1., 2.)

    // Talk about OO vs Functional approach

module OptionTypes = 
    /// Option values are any kind of value tagged with either 'Some' or 'None'.
    /// They are used extensively in F# code to represent the cases where many other
    /// languages would use null references.

    // this is how it is declared in the standard library
    // type Option<'a> = | Some of 'a | None

    type Customer = { realName : string option }

    let unknown = { realName = None }
    let known = { realName = Some "Joe" }
    let getRealName customer =
        match customer.realName with
        | Some name -> name
        | None -> "Anonymous" 
    let x = defaultArg unknown.realName "Anonymous"

    // Option.map
    let value = Some 10
    let multiplyBy2 = (*) 2
    //multiplyBy2 value
    let multiplied = 
        match value with
        | Some x -> Some <| multiplyBy2 x
        | None -> None
    let multiplied2 = value |> Option.map multiplyBy2

    // Option.bind
    let divideBy divBy value  =
        if divBy = 0 then
            None
        else
            Some <| value / divBy
    
    let divideByTen = divideBy 10
    let divided =
        match value with
        | Some x -> 
            match divideByTen x with
            | Some y -> Some y
            | None -> None
        | None -> None

    let divided2 = value |> Option.bind divideByTen


module AdvancedPatternMatching = 

    /// A record for a person's first and last name
    type Person = {     
        First : string
        Last  : string
    }

    /// define a discriminated union of 3 different kinds of employees
    type Employee = 
        | Engineer  of Person
        | Manager   of Person * list<Employee>            // manager has list of reports
        | Executive of Person * list<Employee> * Employee // executive also has an assistant

    /// count everyone underneath the employee in the management hierarchy, including the employee
    let rec countReports(emp : Employee) = 
        1 + match emp with
            | Engineer(id) -> 
                0
            | Manager(id, reports) -> 
                reports |> List.sumBy countReports 
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// find all managers/executives named "Dave" who do not have any reports
    let rec findDaveWithOpenPosition(emps : Employee list) =
        emps 
        |> List.filter(function 
                       | Manager({First = "Dave"}, []) -> true       // [] matches the empty list
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false)                                 // '_' is a wildcard pattern that matches anything
                                                                     // this handles the "or else" case


// ---------------------------------------------------------------
//         EXERCISES
// ---------------------------------------------------------------

// Design types for a domain of a simple calendar system. 
// It should handle e.g. one-time meetings, multiple-time meetings 
// and recurring meetings.
// The class for storing time is called DateTimeOffset.



// Design a deck of card using DUs and Records
// Write function printing all cards in the deck