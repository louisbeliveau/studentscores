namespace StudentScores

module Float=
    let tryFromString s=
        if s="N/A" then
            Some(float 50.0)
        else
            Some(float s)