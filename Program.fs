open System
open System.IO
//allo coco
let printMeanScores (row:string)  =
    let elements = row.Split('\t')
    let name =elements[0]
    let id=elements[1]
    printfn "Id%s Name:%s" row

let sumarize filepath=
    let rows = File.ReadAllLines filepath
    let studentcount = rows.Length - 1
    printfn "Student count %i" studentcount
    rows 
    |> Array.skip 1
    |> Array.iter printMeanScoresprintfn "%s"
    

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
    
    
