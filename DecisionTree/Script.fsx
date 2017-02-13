#r "bin/Debug/DecisionTree.dll"

open Tree

let manualTree =
        Decision(Movie.Action,
                 [|(SplitDecision.No, Leaf "Sch")
                   (SplitDecision.Yes, Decision(Movie.Scifi,
                                       [|(SplitDecision.No, Leaf "St")
                                         (SplitDecision.Yes, Leaf "Sch")|]))|])

let test = [|(Movie.Action,SplitDecision.Yes)
             (Movie.Scifi,SplitDecision.Yes)|]

classify test manualTree