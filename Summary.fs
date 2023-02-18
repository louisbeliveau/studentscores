namespace StudentScores
open System
open System.IO

module Sumary=
    let sumarize (filepath:string)=
        let rows = 
            File.ReadLines filepath           
            |> Seq.cache
        let studentcount = (rows |> Seq.length) - 1
        printfn "Student count %i" studentcount
        rows 
        
        |> Seq.skip 1
        |> Seq.map StudentModule.fromString
        |> Seq.sortBy(fun student->student.FName)
        |> Seq.iter StudentModule.printSummary    