// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let input = System.IO.File.ReadAllLines "testinput.txt"

let directionFromRotation (rotation: string) = if rotation[0] = 'L' then -1 else 1

let deltaFromRotation (rotation: string) =
    if rotation = "0" then
        0
    else
        directionFromRotation rotation * int rotation[1..]

let deltasFromRotations (rotations: List<string>) = rotations |> List.map deltaFromRotation

let rotations = input |> Seq.toList |> deltasFromRotations

let rec applyRotations (start: int) (rotations: List<int>) = // start + sumOf rotations
    match rotations with
    | [] -> start
    | head :: tail ->
        let newState = (start + head) % 100
        // printfn "%d\t%d" head newState
        start + head + applyRotations newState tail

// let rec rotateUntil (rotations: List<int>) =
//     match rotations with
//     | [] -> 0
//     | head :: tail ->


let initial = 50

printfn "Initial state: %d" initial
printf "\n"

let final = rotations |> applyRotations initial

printfn "Final state: "
