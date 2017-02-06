#r "bin/Debug/KNearestNeighbor.dll"

open Knn
open System
open System.IO

let filename = Path.Combine(__SOURCE_DIRECTORY__, "../Data/train.csv")
let data,labels = loadData filename

//load test data and compute result