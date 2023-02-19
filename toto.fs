namespace StudentScores

    

module toto =
    open System.IO

    let load (filepath:string) =
        File.ReadAllLines filepath
        |> Seq.skip 1
        |> Seq.map (fun row -> 
            let elements = row.Split('\t') 
            let id = elements[0] |> int 
            let name = elements[1]
            id, name)
    
        