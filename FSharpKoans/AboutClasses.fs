﻿namespace FSharpKoans
open FSharpKoans.Core

type Zombie() =
    member this.FavoriteFood = "brains"

    member this.Eat food =
        match food with
        | "brains" -> "mmmmmmmmmmmmmmm"
        | _ -> "grrrrrrrr"

type Person(name:string) =
    member this.Speak() =
        "Hi my name is " + name

type Zombie2() =
    let favoriteFood = "brains"

    member this.Eat food =
        if food = favoriteFood then "mmmmmmmmmmmmmmm" else "grrrrrrrr"

type Person2(name:string) =
    let mutable internalName = name

    member this.Name
        with get() = internalName
        and set(value) = internalName <- value

    member this.Speak() =
        "Hi my name is " + this.Name

type ``about classes``() =

    [<Koan>]
    member this.ClassesCanHaveProperties() =
        let zombie = new Zombie()

        AssertEquality zombie.FavoriteFood "brains"

    [<Koan>]
    member this.ClassesCanHaveMethods() =
        let zombie = new Zombie()

        let result = zombie.Eat "brains"
        AssertEquality result "mmmmmmmmmmmmmmm"
    
    [<Koan>]
    member this.ClassesCanHaveConstructors() =
    
        let person = new Person("Shaun")

        let result = person.Speak()
        AssertEquality result "Hi my name is Shaun"

    [<Koan>]
    member this.ClassesCanHaveLetBindingsInsideThem() =
        let zombie = new Zombie2()

        let result = zombie.Eat "chicken"
        AssertEquality result "grrrrrrrr"

        (* TRY IT: Can you access the let bound value Zombie2.favoriteFood
                   outside of the class definition? *)

    [<Koan>]
    member this.ClassesCanHaveReadWriteProperties() =
        let person = new Person2("Shaun")

        let firstPhrase = person.Speak()
        AssertEquality firstPhrase "Hi my name is Shaun"

        person.Name <- "Shaun of the Dead"
        let secondPhrase = person.Speak()
        AssertEquality secondPhrase "Hi my name is Shaun of the Dead"