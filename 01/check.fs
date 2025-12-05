module Test

open PassingNorth

let Test () : int =
    printfn "expecting %d, got %d" 0 (countRotationsLeft 0 -5)
    printfn "expecting %d, got %d" 0 (countRotationsLeft 10 -5)
    printfn "expecting %d, got %d" 1 (countRotationsLeft 10 -15)
    printfn "expecting %d, got %d" 2 (countRotationsLeft 10 -110)
    printfn "expecting %d, got %d" 2 (countRotationsLeft 10 -160)
    printfn "expecting %d, got %d" 3 (countRotationsLeft 10 -210)
    printfn "expecting %d, got %d" 3 (countRotationsLeft 10 -260)
    printfn "expecting %d, got %d" 4 (countRotationsLeft 10 -310)
    printfn "expecting %d, got %d" 6 (countRotationsLeft 10 -520)
    printfn "expecting %d, got %d" 0 (countRotationsLeft 80 -5)

    0

let TestAndExitOrContinue (run: bool) : unit = if not run then () else exit (Test())
