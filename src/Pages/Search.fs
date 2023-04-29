module Pages.Search

open Fable.Core
open Vide
open type Html



[<Erase; Mangle false>]
type private Views =

  static member QueryForm() = vide {
    form {
      fieldset.class' ("uk-fieldset") {
        legend.class' ("uk-legend") { "Search movies by title!" }
      }
    }
  }


let View () = vide {
  h1 { "Vide Movies" }
  Views.QueryForm()
}
