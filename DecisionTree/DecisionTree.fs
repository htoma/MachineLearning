module Tree

type Movie =
    | Action
    | Scifi

type SplitDecision =
    | Yes
    | No

type Node<'a,'b> =
    | Leaf of string
    | Decision of 'a * ('b * Node<'a,'b>)[]

let rec classify subject node =
    match node with
    | Leaf c -> c
    | Decision(label, subnodes) ->
            let findAttributeValue =
                subject
                |> Seq.find(fun (key, value) -> key = label)
                |> snd
            subnodes
                |> Array.find (fun (option, _) -> option = findAttributeValue)
                |> snd
                |> classify subject
