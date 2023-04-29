module Components.Navbar

open Fable.Core

open Vide
open type Html

open Types


[<Erase; Mangle false>]
type Navbar =

  static member Navbar
    (
      ?onApiKeyChanged: (string -> unit),
      ?onPageSelected: (Pages -> unit)
    ) =
    let navPages = section.class' ("uk-navbar-left") {
      ul.class' ("uk-navbar-nav") {
        li {
          button
            .class'("uk-button uk-button-link")
            .onclick (fun _ ->
              onPageSelected
              |> Option.map (fun callback -> callback Pages.Landing)
              |> ignore) {
            "Home"
          }
        }

        li {
          button
            .class'("uk-button uk-button-link")
            .onclick (fun _ ->
              onPageSelected
              |> Option.map (fun callback -> callback Pages.Search)
              |> ignore) {
            "Search"
          }
        }
      }
    }

    let navInput = section.class' ("uk-navbar-right") {
      div.class' ("uk-navbar-item") {
        input
          .type'("text")
          .class'("uk-input")
          .placeholder("OMDb API Key")
          .oninput (fun e ->
            onApiKeyChanged
            |> Option.map (fun callback -> callback e.node.value)
            |> ignore)
      }
    }

    vide {
      nav.class' ("uk-navbar-container uk-margin") {
        div.class' ("uk-container") {
          div.attr ("uk-navbar", "") {
            navPages
            navInput
          }
        }
      }
    }
