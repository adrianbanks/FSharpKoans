namespace FSharpKoans
open FSharpKoans.Core
open System.Collections.Generic

type ``about dot net collections``() =

    [<Koan>]
    member this.CreatingDotNetLists() =
        let fruits = new List<string>()

        fruits.Add("apple")
        fruits.Add("pear")
 
        AssertEquality fruits.[0] "apple"
        AssertEquality fruits.[1] "pear"

    [<Koan>]
    member this.CreatingDotNetDictionaries() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        AssertEquality addressBook.["Chris"] "Ann Arbor"
        AssertEquality addressBook.["SkillsMatter"] "London"

    [<Koan>]
    member this.YouUseCombinatorsWithDotNetTypes() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        let verboseBook = 
            addressBook
            |> Seq.map (fun kvp -> sprintf "Name: %s - City: %s" kvp.Key kvp.Value)
            |> Seq.toArray

        AssertEquality verboseBook.[0] "Name: Chris - City: Ann Arbor"
        AssertEquality verboseBook.[1] "Name: SkillsMatter - City: London"