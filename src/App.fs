module App

open Browser
open Vide
open type Html

Fable.Core.JsInterop.emitJsStatement
  ()
  """
import UIkit from 'uikit';
import Icons from 'uikit/dist/js/uikit-icons.js';

// loads the Icon plugin
UIkit.use(Icons);"""

open Types
open Components.Navbar

open type Navbar

let App () =

  let inline setApiKey (value: MutableValue<string>) (key: string) =
    value.Value <- key

  let inline setPage (value: MutableValue<Pages>) (page: Pages) =
    value.Value <- page


  vide {
    let! apiKey = Vide.ofMutable ""
    let! currentPage = Vide.ofMutable Pages.Landing

    Navbar(setApiKey apiKey, setPage currentPage)

    article.class' ("uk-container") {
      match currentPage.Value with
      | Pages.Movie id -> Pages.Movie.View id
      | Pages.Landing -> Pages.Landing.View()
      | Pages.Search -> Pages.Search.View()
    }
  }


let host = document.getElementById ("app")
VideApp.Fable.createAndStart host (App()) |> ignore
