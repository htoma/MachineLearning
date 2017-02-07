#r "bin/Debug/KNearestNeighbor.dll"

open Knn
open System
open System.IO

let data, labels = loadTrainData (Path.Combine(__SOURCE_DIRECTORY__, "../Data/train.csv"))

//let testData = loadTestData (Path.Combine(__SOURCE_DIRECTORY__, "../Data/test.csv"))

let trainSize = data.Length * 2 / 3

let dataTrain, labelsTrain = data |> Array.take trainSize, labels |> Array.take trainSize
let testSet = Array.zip (data |> Array.skip trainSize) (labels |> Array.skip trainSize)

#time

let result = [6..7]
             |> List.map (fun k -> 
                                k,testSet
                                    |> Array.take 10
                                    |> Array.filter (fun (p,l) -> (classify p dataTrain labelsTrain k)<>l)
                                    |> Array.length)
                   
#time

result