module Views

open Giraffe.GiraffeViewEngine

let indexView =
    html [] [
        head [] [
            title [] [ str "Giraffe Sample" ]
            link [
                _rel  "stylesheet"
                _type "text/css"
                _href "/styles/main.css" ]
            script [
                attr "src" "/scripts/lib.js"
                attr "lang" "javascript" ] []
        ]
        body [] [
            img [ attr "src" "/images/mancfug.png" ]
            h1 [] [ str "I |> F#" ]
            p [ _class "some-css-class"; _id "someId" ] [
                str "Hello World"
            ]
        ]
    ]