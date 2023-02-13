open System
open System.IO
open StudentScores    
open StudentScores.Sumary

[<EntryPoint>]
let main argv=
    if argv.Length = 1 then
        let filepath = argv[0] 
        if File.Exists filepath then
            printfn "Processing %s" filepath
            try
                sumarize filepath               
                0
            with
            | :? FormatException as e ->
                printfn "Error: %s" e.Message
                printfn "Le fichier n est pas dans le format attendu"
                1    
        else
            printfn "the file doesnt even exits you freak"
            1 
    else
        printfn "Please specify a file"
        2
    
    
