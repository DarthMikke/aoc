module aoc

open Parse
open PassingNorth
open Test

let isZero (n: int, _: int) = n = 0

let passesOfNorth (count: int) (_: int, n: int) = n + count

let addRotation (previousRotations: List<int * int>) (value: int, _) : List<int * int> = // start + sumOf rotations
    let lastState, _ = previousRotations |> List.last
    let newValue = rotateBy lastState value

    let turns = rotationsThroughNorth lastState value

    List.append previousRotations [ (newValue, turns) ]

let filename = System.Environment.GetCommandLineArgs()[1]

TestAndExitOrContinue(filename = "test")

printfn "Opening %s" filename

let rotations =
    filename
    |> System.IO.File.ReadAllLines
    |> Seq.toList
    |> deltasFromRotations
    |> List.map (fun (x: int) -> x, 0)


// main code block below

let initial = 50

printfn "Initial state: %d" initial
printf "\n"

let states = List.fold addRotation [ (initial, 0) ] rotations

// if rotations.Length > 20 then
//    printfn "Too see state at every rotation, pass at most 20 rotations."
// else
let printDelta (delta, turns: int) (state, _: int) = printfn "%d\t%d\t%d" state delta turns

List.iter2 printDelta states (rotations |> List.append [ (0, 0) ])

let zeroes = List.filter isZero states
let passingsOfNorth = List.fold passesOfNorth 0 states

printfn
    "Counted:
%A zeroes
%A passings of zero"
    zeroes.Length
    passingsOfNorth
