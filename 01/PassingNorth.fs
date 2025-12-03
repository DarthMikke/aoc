module PassingNorth

let passingNorth (start: int) (rotation: int) : int = (start + rotation) / 100

let rotationsThroughNorth (initial: int) (rotations: int list) : (int list) =
    List.fold (passingNorth initial) rotations
