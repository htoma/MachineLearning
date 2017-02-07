#r "bin/Debug/KNearestNeighbor.dll"

open Knn
open System.IO

let data, labels = loadTrainData (Path.Combine(__SOURCE_DIRECTORY__, "../Data/train.csv"))

let trainsetDigitSize = 500
let testsetDigitSize = 100

let all = Array.zip data labels
          |> Array.groupBy (fun (d,l) -> l)

let train = all
            |> Array.map (fun (_,x) -> x |> Array.take trainsetDigitSize)  
            |> Array.concat

let test = all
            |> Array.map (fun (_,x) -> x 
                                        |> Array.skip trainsetDigitSize
                                        |> Array.take testsetDigitSize)  
            |> Array.concat

//let testData = loadTestData (Path.Combine(__SOURCE_DIRECTORY__, "../Data/test.csv"))
//let trainSize = data.Length * 2 / 3

#time

let result = [1..50]
             |> List.map (fun k -> 
                                k,test
                                    |> Array.filter (fun (p,l) -> (classify p train k)<>l)
                                    |> Array.length)
                   
#time

result
