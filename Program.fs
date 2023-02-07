open System
open System.IO

module Float=
    let tryFromString s=
        if s="N/A" then
            Some(float 50.0)
        else
            Some(float s)

    
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
            |> Array.choose Float.tryFromString
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

    // let fromStringOr50 s=
    //     if s=="N/A" then
    //         Float.tryFromString 
    //     0

    let printSummary (student:Student)  =
        printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.FName student.LName student.Id student.MeanScore student.MinScore student.MaxScore

let sumarize (filepath:string)=
    let rows = File.ReadAllLines filepath
    let studentcount = rows.Length - 1
    printfn "Student count %i" studentcount
    rows 
    |> Array.skip 1
    |> Array.map StudentModule.fromString
    |> Array.sortBy(fun student->student.FName)
    |> Array.iter StudentModule.printSummary    

[<EntryPoint>]
let main argv=
    if argv.Length = 1 then
        let filepath = argv[0] 
        if File.Exists filepath then
            printfn "Processing %s" filepath
            sumarize filepath
            0
        else
            printfn "the file doesnt even exits you freak"
            1 
    else
        printfn "Please specify a file"
        2
    
    
