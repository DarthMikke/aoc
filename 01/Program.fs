module aoc

open Parse

let addRotation (previousRotations: List<int>) (value: int) : List<int> = // start + sumOf rotations
    let newValue = (List.last previousRotations + value) % 100
    List.append previousRotations [ newValue ]

let filename = System.Environment.GetCommandLineArgs()[1]

printfn "Opening %s" filename

let rotations =
    filename |> System.IO.File.ReadAllLines |> Seq.toList |> deltasFromRotations

let isZero (n: int) = n = 0



let initial = 50

printfn "Initial state: %d" initial
printf "\n"

let states = List.fold addRotation [ initial ] rotations

if rotations.Length > 20 then
    printfn "Too see state at every rotation, pass at most 20 rotations."
else
    let printDelta (delta: int) (state: int) = printfn "%d\t%d" state delta
    rotations |> List.append [ 0 ] |> Seq.iter2 printDelta states

let zeroes = List.filter isZero states

printfn "Counted %A zeroes" zeroes.Length
