#I "c:/work/MachineLearning/packages/FSharp.Charting.0.90.14"

#load "FSharp.Charting.fsx"

open System
open FSharp.Charting

// Define your library scripting code here

let createDataSet =
    [| [|1.0; 0.9|]
       [|0.8; 1.0|]
       [|0.8; 0.9|]
       [|0.0; 0.1|]
       [|0.3; 0.0|]
       [|0.1; 0.1|] |],
    [| "A"; "A"; "A"; "B"; "B"; "B" |]

let scatterplot (dataset: float[][]) =
    dataset
    |> Array.map (fun e -> e.[0], e.[1])
    |> Chart.FastPoint

let data, labels = createDataSet

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

//data |> scatterplot
display data labels

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

classify [|0.7; 0.4|] data labels 3