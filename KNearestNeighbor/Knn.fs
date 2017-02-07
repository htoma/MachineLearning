module Knn

open System
open System.IO
open FSharp.Charting

let display (points: float[][]) (labels: string[]) =
    let data = points
                |> Array.map (fun p -> p.[0],p.[1])
                |> Array.zip labels

    let uniqueLabels = Seq.distinct labels
    
    Chart.Combine(
        [ for label in uniqueLabels ->
                let data = data
                            |> Array.filter (fun e  -> label = fst e)
                            |> Array.map snd
                Chart.Point(data).WithDataPointLabels(label)
        ])

let distanceEuclid (v1: float[]) (v2: float[]) =
    Array.fold2 (fun s e1 e2 -> s+Math.Pow((e1-e2), 2.0)) 0.0 v1 v2
    |> sqrt

let classify point data labels k =
    Array.zip data labels
    |> Array.map (fun (v,l) -> distanceEuclid v point,l)
    |> Array.sortBy fst
    |> Array.take k
    |> Array.countBy snd
    |> Array.sortByDescending fst
    |> Array.map fst
    |> Array.head

let loadTrainData filename =
    let content = File.ReadAllLines(filename)
    
    let converted = content
                     |> Array.skip 1
                     |> Array.map (fun l -> l.Split([|','|]))
                     |> Array.map (fun e -> e.[0],
                                            e.[1..]
                                            |> Array.map (fun s -> s |> Convert.ToDouble))

    converted |> Array.map snd, converted |> Array.map fst

let loadTestData filename = 
    let content = File.ReadAllLines(filename)
    
    content
    |> Array.skip 1
    |> Array.map (fun l -> l.Split([|','|])
                        |> Array.map (fun s -> s |> Convert.ToDouble)
                )
