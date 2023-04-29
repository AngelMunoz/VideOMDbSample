module Pages.Landing

open Fable.Core
open Vide
open type Html

open Types
open Components.Navbar
open Components.Card

open type Navbar
open type Card

let View () = vide { h1 { "Landing Page" } }
