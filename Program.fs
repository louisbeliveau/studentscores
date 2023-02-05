open System
open System.IO

type Student=
    {
        Name:string
        Id:string
        MeanScore:float
        MinScore:float
        MaxScore:float
    }
module Student=
    let fromString(s:string)=
        let elements = s.Split('\t')
        let name =elements[0]
        let id=elements[1]
        let scores =
            elements
            |> Array.skip 2
            |> Array.map float
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {            
           Id=id
           Name=name
           MeanScore=meanScore
           MinScore=minScore
           MaxScore=maxScore
        }    

let printMeanScore (row:string)  =
    printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" name id meanScore minScore maxScore

let sumarize filepath=
    let rows = File.ReadAllLines filepath
    let studentcount = rows.Length - 1
    printfn "Student count %i" studentcount
    rows 
    |> Array.skip 1
    |> Array.iter printMeanScore
    

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
    
    
