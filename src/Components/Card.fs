module Components.Card

open Fable.Core
open Vide
open type Html

[<Erase; RequireQualifiedAccessAttribute>]
type CardType =
  | [<CompiledName "uk-card-default">] Default
  | [<CompiledName "uk-card-primary">] Primary
  | [<CompiledName "uk-card-secondary">] Secondary

[<Erase; Mangle false>]
type Card =

  static member Card
    (
      content: unit -> Vide<_, _, _>,
      ?header: (unit -> Vide<_, _, _>),
      ?footer: (unit -> Vide<_, _, _>)
    ) =

    vide {

      div.class' ($"uk-card uk-card-default uk-card-hover") {

        match header with
        | Some header -> Html.header.class' ("uk-card-header") { header () }
        | None -> Vide.elseForget

        div.class' ("uk-card-body") { content () }

        match footer with
        | Some footer -> Html.footer.class' ("uk-card-footer") { footer () }
        | None -> Vide.elseForget
      }

    }
