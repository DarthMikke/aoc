module aoc

open Parse
open PassingNorth

let addRotation (previousRotations: List<int * int>) (value: int) : List<int * int> = // start + sumOf rotations
    let lastState, _ = previousRotations |> List.last
    let newValue = (lastState + value) % 100
    List.append previousRotations [ (newValue, 0) ]

let filename = System.Environment.GetCommandLineArgs()[1]

printfn "Opening %s" filename

let rotations =
    filename |> System.IO.File.ReadAllLines |> Seq.toList |> deltasFromRotations

let rotationsWithFullTurns = rotations |> Seq.map (fun (x: int) -> x, 0)

let isZero (n: int, _: int) = n = 0



let initial = 50

printfn "Initial state: %d" initial
printf "\n"

let states = List.fold addRotation [ (initial, 0) ] rotations

if rotations.Length > 20 then
    printfn "Too see state at every rotation, pass at most 20 rotations."
else
    let printDelta (delta: int) (state: int) = printfn "%d\t%d" state delta
    rotationsWithFullTurns |> List.append [ (0, 0) ] |> Seq.iter2 printDelta states

let zeroes = List.filter isZero states

printfn "Counted %A zeroes" zeroes.Length

let passinggsOfNorth = rotations

let passingNorth = List.fold (fun (a: int) (b: int) -> a + b) 50 rotations
