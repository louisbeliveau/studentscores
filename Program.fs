open System
open System.IO

let printMeanScore (row:string)  =
    let elements = row.Split('\t')
    let name =elements[0]
    let id=elements[1]
    let meanScore =
        elements
        |> Array.skip 2
        |> Array.averageBy float
    printfn "%s\t%s\t%0.1f" name id meanScore

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
    
    
