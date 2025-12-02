/// Functions for parsing string representation of notations such as
/// 'L5' or 'R18' to their int representations: -5 or 18.
module Parse

let directionFromRotation (rotation: string) = if rotation[0] = 'L' then -1 else 1

let deltaFromRotation (rotation: string) =
    if rotation = "0" then
        0
    else
        directionFromRotation rotation * int rotation[1..]

let deltasFromRotations (rotations: List<string>) = rotations |> List.map deltaFromRotation
