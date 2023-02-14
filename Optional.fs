namespace StudentScores

type Optional<'T> =
    | Something of 'T
    | Nothing

module Demo =

    let a = Something "abc"
    let b = Something 1
    let c = Something 100000000
    let d = Nothing