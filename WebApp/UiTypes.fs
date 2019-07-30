module UiTypes

[<CLIMutable>]
type Terms = {
    Term1: string
    Term2: string
}

type Answer = {
    WinningTerm: string
    LosingTerm: string
    Difference: int
}
