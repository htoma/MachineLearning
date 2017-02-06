#I "C:/work/MachineLearning/packages/FSharp.Data.2.3.2/lib/net40"
#r "FSharp.Data.dll"

open System
open FSharp.Data


type DigitTypeProvider = CsvProvider<"../Data/digits.csv",HasHeaders=false>

let sample = DigitTypeProvider.GetSample()

let columns = sample.NumberOfColumns
let result = sample.Rows
                |> Seq.skip 1
                |> Seq.take 1
                |> Seq.cast<CsvRow>
                |> Seq.map (fun r -> r.Columns)
                |> Array.ofSeq


