module PassingNorth

let wrap (value: int) =
    if value < 0 then 100 + value else value

let rotateBy lastState value = (lastState + value) % 100 |> wrap

let passingNorth (start: int) (rotation: int) : int = (start + rotation) / 100

let countRotationsLeft (initial: int) (delta: int) : (int) =
    let adjust = if initial = 0 then 0 else 1
    let beyondZero = 0 - delta - initial
    printfn "degrees beyond north: %d" beyondZero

    if beyondZero < 0 then 0 else beyondZero / 100 + adjust


let countRotationsRight (initial: int) (delta: int) : (int) = (initial + delta) / 100

let rotationsThroughNorth (initial: int) (delta: int) : (int) =
    if delta < 0 then
        countRotationsLeft initial delta
    else
        countRotationsRight initial delta
