namespace StudentScores
open System
open System.IO

module Sumary=
    let sumarize (filepath:string)=
        let rows = File.ReadAllLines filepath
        let studentcount = rows.Length - 1
        printfn "Student count %i" studentcount
        rows 
        |> Array.skip 1
        |> Array.map StudentModule.fromString
        |> Array.sortBy(fun student->student.FName)
        |> Array.iter StudentModule.printSummary    