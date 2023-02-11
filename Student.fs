namespace StudentScores

type Student=
    {
        FName:string
        LName:string
        Id:string
        MeanScore:float
        MinScore:float
        MaxScore:float
    }
module StudentModule=
    let fromString(s:string)=
        let elements = s.Split('\t')
        let name =elements[0].Split(",")
        let id=elements[1]
        let scores =
            elements
            |> Array.skip 2
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {             
        Id=id
        FName=name[1]
        LName=name[0]
        MeanScore=meanScore
        MinScore=minScore
        MaxScore=maxScore
        }

    let printSummary (student:Student)  =
        printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.FName student.LName student.Id student.MeanScore student.MinScore student.MaxScore
